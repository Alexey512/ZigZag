using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UnityEngine.AI;

namespace Assets.Scripts.Game.Commands
{
	public class MoveByPath: Command
	{
		private readonly IUnit _unit;

		private readonly Vector3[] _path;

		private readonly float _duration;

		private Tween _tween;

		public MoveByPath(IUnit unit, Vector3[] path, float duration)
		{
			_unit = unit;
			_path = path;
			_duration = duration;
		}

		protected override void OnExecute()
		{
			if (_path.Length == 0)
			{
				Finish();
				return;
			}
			_tween = _unit.Owner.transform.DOPath(_path, _duration);
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
