namespace Assets.Scripts.Game.Units
{
	public interface IUnitsFactory
	{
		T CreateUnit<T>(string unitId) where T : class, IUnit;
	}
}
