using UnityEngine;

namespace Assets.Scripts.Game.Units
{
	public class Unit: MonoBehaviour, IUnit
	{
		public GameObject Owner => gameObject;

		[SerializeField]
		private float _attack = 0;

		[SerializeField]
		private float _hp = 0;

		public float Attack
		{
			get { return _attack; }
			set { _attack = value; }
		}

		public float HP
		{
			get { return _hp; }
			set { _hp = value; }
		}

		public Vector3 Position
		{
			get { return transform.position; }
			set { transform.position = value; }
		}

		public Quaternion Rotation
		{
			get { return this.transform.rotation; }
			set { this.transform.rotation = value; }
		}
	}
}
