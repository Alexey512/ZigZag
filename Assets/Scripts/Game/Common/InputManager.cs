using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Game.Common
{
	public class InputManager: MonoBehaviour, IInputManager
	{
		[SerializeField]
		private Camera _camera;

		public event Action<RaycastHit> OnClick;

	    public event Action<Vector3> OnMouseDown;

        private void Update()
		{
			if (IsOverGUI())
				return;

			if (Input.GetMouseButtonDown(0))
			{
			    OnMouseDown?.Invoke(Input.mousePosition);

                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					OnClick?.Invoke(hit);
				}
			}
		}

		private bool IsOverGUI()
		{
			if (UnityEngine.EventSystems.EventSystem.current == null)
				return false;
			if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
				return true;

			if (Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Ended)
			{
				if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
					return true;
			}

			return false;
		}
	}
}
