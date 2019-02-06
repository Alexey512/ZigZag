using Assets.Scripts.Common.UI;
using UnityEngine;

namespace Assets.Scripts.Game.UI
{
	public class WindowRoot: MonoBehaviour, IWindowRoot
	{
		public Transform Root => this.transform;
	}
}
