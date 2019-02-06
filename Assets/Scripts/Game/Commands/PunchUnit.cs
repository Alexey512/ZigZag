using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Game.Commands
{
	public class PunchUnit: Command
	{
		private readonly IUnit _unit;

		private readonly Vector3 _punch;

		private readonly float _duration;

		private Tween _tween;

		public PunchUnit(IUnit unit, Vector3 punch, float duration)
		{
			_unit = unit;
			_punch = punch;
			_duration = duration;
		}

		protected override void OnExecute()
		{
			_tween = _unit.Owner.transform.DOPunchScale(_punch, _duration);
			_tween.OnComplete(Finish);
		}

		protected override void OnComplete()
		{
			Clear();
		}

		protected override void OnTerminate()
		{
			_tween?.Kill(false);
			Clear();
		}

		private void Clear()
		{
			_tween = null;
		}
	}
}
