using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Game.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.UI.Controller
{
	public class WindowController: MonoBehaviour, IWindowController, IPoolable<IMemoryPool>
    {
		public Transform Owner => this.transform;

        protected IWindowContext Context;

        private UIManager _uiManager;

        [Inject]
        public void Construct(IWindowContext context, UIManager uiManager)
        {
            Context = context;
            _uiManager = uiManager;

            OnCreate();
        }

		protected virtual void OnCreate()
		{

		}

        protected virtual void OnShow()
        {

        }

        protected virtual void OnHide()
        {

        }

        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            //_uiManager.AddWindow(this);
            OnShow();
        }

        public void OnDespawned()
        {
            _pool = null;
            //_uiManager.RemoveWindow(this);
            OnHide();
        }

        public void Hide()
        {
            _pool?.Despawn(this);
        }
    }
}
