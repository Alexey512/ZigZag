using Assets.Scripts.Common.UI.Context;
using UnityEngine;

namespace Assets.Scripts.Common.UI.Controller
{
	public class WindowController: MonoBehaviour, IWindowController
	{
		public Transform Owner => this.transform;

		private void Start()
		{
			OnCreate();
		}

		protected virtual void OnCreate()
		{

		}

		public virtual void Initialize(IWindowContext context)
		{
			
		}
	}
}
