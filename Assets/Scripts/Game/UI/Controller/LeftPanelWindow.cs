using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Common.UI.Controller;
using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.UI.Controller
{
	public class LeftPanelWindow: WindowController
	{
		[SerializeField]
		private Toggle _createToggle;

		[SerializeField]
		private Toggle _moveToggle;

		[SerializeField]
		private Toggle _attackToggle;

		private IWindowContext _context;

		protected override void OnCreate()
		{
			_createToggle.onValueChanged.AddListener(OnSetCreateState);
			_moveToggle.onValueChanged.AddListener(OnSetMoveState);
			_attackToggle.onValueChanged.AddListener(OnAttackState);
		}

		public override void Initialize(IWindowContext context)
		{
			_context = context;
		}

		private void OnSetCreateState(bool isCheck)
		{
		    //if (isCheck)
			//	_actionContext.Publisher.Publish<SetInputStateEvent, eInputState>(eInputState.Create);
		}

		private void OnSetMoveState(bool isCheck)
		{
			//if (isCheck)
			//	_actionContext.Publisher.Publish<SetInputStateEvent, eInputState>(eInputState.Move);
		}

		private void OnAttackState(bool isCheck)
		{
			//if (isCheck)
			//	_actionContext.Publisher.Publish<SetInputStateEvent, eInputState>(eInputState.Attack);
		}
	}
}
