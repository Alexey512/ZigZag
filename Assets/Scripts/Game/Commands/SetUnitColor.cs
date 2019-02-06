using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Commands
{
	public class SetUnitColor: Command
	{
		private readonly IUnit _unit;

		private readonly Color _color;

		public SetUnitColor(IUnit unit, Color color)
		{
			_unit = unit;
			_color = color;
		}

		protected override void OnExecute()
		{
			GameObject content = FindChildRecursive(_unit.Owner.transform, "View");
			if (content != null)
			{
				var renderet = content.GetComponent<MeshRenderer>();
				if (renderet != null)
					renderet.material.color = _color;
			}
			Finish();
		}

		private GameObject FindChildRecursive(Transform parent, string childName)
		{
			GameObject findedObject = null;
			foreach (Transform child in parent)
			{
				if (child.name == childName)
				{
					return child.gameObject;
				}
				else
				{
					findedObject = FindChildRecursive(child, childName);
				}
			}
			return findedObject;
		}

		protected override void OnTerminate()
		{
		}
	}
}
