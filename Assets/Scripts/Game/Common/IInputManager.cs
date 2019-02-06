using System;
using UnityEngine;

namespace Assets.Scripts.Game.Common
{
	public interface IInputManager
	{
		event Action<RaycastHit> OnClick;

	    event Action<Vector3> OnMouseDown;
    }
}
