using Assets.Scripts.Common.Commands;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Commands
{
	public class CreateUnit: Command
	{
		private readonly string _unitId;

		private readonly Vector3 _position;

		private readonly IUnitsFactory _factory;

		public CreateUnit(IUnitsFactory factory, string unitId, Vector3 position)
		{
			_unitId = unitId;
			_position = position;
			_factory = factory;
		}


		protected override void OnExecute()
		{
			
		}

		protected override void OnTerminate()
		{
			throw new System.NotImplementedException();
		}
	}
}
