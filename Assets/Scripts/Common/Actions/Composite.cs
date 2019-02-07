using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Common.Actions
{
	public abstract class Composite : GameAction, ICollection<IGameAction>
	{
		private readonly HashSet<IGameAction> _childs = new HashSet<IGameAction>();

        protected Composite()
        {
        }

	    protected Composite(params IGameAction[] actions)
		{
			foreach (var action in actions)
			{
				Add(action);
			}
		}

		public IEnumerator<IGameAction> GetEnumerator()
		{
			return _childs.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_childs).GetEnumerator();
		}

        public void AddRange(IEnumerable<IGameAction> items)
        {
            if (Status == ActionStatus.Running)
                throw new Exception("Can't add child's during action running");

            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(IGameAction item)
		{
            if (Status == ActionStatus.Running)
                throw new Exception("Can't add child's during action running");

		    _childs.Add(item);
            OnAdd(item);
		}

		protected virtual void OnAdd(IGameAction item)
		{
		}

		public void Clear()
		{
			_childs.Clear();
		}

		public bool Contains(IGameAction item)
		{
			return _childs.Contains(item);
		}

		public void CopyTo(IGameAction[] array, int arrayIndex)
		{
			_childs.CopyTo(array, arrayIndex);
		}

		public bool Remove(IGameAction item)
		{
		    if (Status == ActionStatus.Running)
		        throw new Exception("Can't remove child's during action running");

            if (_childs.Remove(item))
			{
				OnRemove(item);
				return true;
			}
			return false;
		}

		protected virtual void OnRemove(IGameAction item)
		{
		}

		public int Count => _childs.Count;

		public bool IsReadOnly => ((ICollection<IGameAction>)_childs).IsReadOnly;

	    protected override void OnUpdate()
	    {
	        base.OnUpdate();

	        foreach (var child in _childs)
	        {
                if (child.Status == ActionStatus.Running)
	                child.Update();
            }
	    }
	}
}
