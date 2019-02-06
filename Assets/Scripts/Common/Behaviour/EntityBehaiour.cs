using System.Collections.Generic;
using Assets.Scripts.Common.Actions;
using UnityEngine;

namespace Assets.Scripts.Common.Behaviour
{
    public enum BehaiourState
    {
        None = 0,
        Create = 1,
        Destroy = 2,
        Move = 3,
    }

    public class EntityBehaiour
    {
        private ActionContext _context = new ActionContext();

        public ActionContext Context => _context;

        private readonly Dictionary<BehaiourState, IGameAction> _behaviours = new Dictionary<BehaiourState, IGameAction>();

        private BehaiourState _state;

        private IGameAction _current;

        public void SelectState(BehaiourState state)
        {
            Stop();

            IGameAction action;
            if (!_behaviours.TryGetValue(state, out action))
                return;
            _current = action;
            _state = state;
            _current.Ended += OnActionEnd;
            _current.Start();
        }

        public void Register(BehaiourState state, IGameAction action)
        {
            InitializeContext(action);
            _behaviours[state] = action;
        }

        private void InitializeContext(IGameAction action)
        {
            var task = action as GameTask;
            if (task != null)
                task.Context = Context;
            var composite = action as Composite;
            if (composite != null)
                foreach (var child in composite)
                {
                    InitializeContext(child);
                }
        }

        private void OnActionEnd(IGameAction action)
        {
            Stop();
        }

        public void Stop()
        {
            if (_current != null)
            {
                _current.Ended -= OnActionEnd;
                _current.End(ActionStatus.Inactive);
                _current = null;
            }
            _state = BehaiourState.None;
        }

        public void Clear()
        {
            Stop();
            _context.Clear();
        }

        public void Update()
        {
            _current?.Update();
        }
    }
}
