using Assets.Scripts.Common.Entity;

namespace Assets.Scripts.Game.Factory
{
    public interface IEntityFactory
    {
        T CreateEntity<T>(EntityType type) where T : class, IGameEntity;
    }
}
