using Assets.Scripts.Common.Actions;
using Game.Objects.Logic;
using UnityEngine;

namespace Game.Objects.Logics
{
	public class WaitForSecondAction : GameTask
	{
		private float _delay;

	    private float _leftTime;

        public WaitForSecondAction(float delay)
		{
			_delay = delay;
		}

		protected override void OnStart()
		{
		    _leftTime = _delay;
		}

		protected override void OnUpdate()
		{
		    if (_leftTime < 0)
		    {
                End(ActionStatus.Success);
                return;
		    }

		    _leftTime -= Time.deltaTime;
		}
	}
}
