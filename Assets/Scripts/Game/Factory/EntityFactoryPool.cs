using System.Collections.Generic;
using Assets.Scripts.Common.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Factory
{
    public class EntityFactoryPool: MonoBehaviour, IEntityFactory
    {
        [SerializeField]
        private EntityPrefabsAsset _asset;

        private static int _objectId;

        private readonly Dictionary<EntityType, EntityPrefabsAsset.PrefabItem> _cache = new Dictionary<EntityType, EntityPrefabsAsset.PrefabItem>();

        private readonly Dictionary<EntityType, Stack<IGameEntity>> _pool = new Dictionary<EntityType, Stack<IGameEntity>>();

        public T CreateEntity<T>(EntityType type) where T : class, IGameEntity
        {
            if (_asset == null)
                return null;
            IGameEntity entity = null;
            Stack<IGameEntity> pool;
            if (_pool.TryGetValue(type, out pool))
            {
                entity = pool.Pop();
                if (entity != null)
                {
                    entity.Initialize(_objectId++, type);
                    entity.Owner.SetActive(true);
                    entity.Owner.transform.parent = null;
                    return entity as T;
                }
            }

            EntityPrefabsAsset.PrefabItem item;
            if (!_cache.TryGetValue(type, out item))
            {
                item = _asset.GetItem(type);
                if (item == null)
                    return null;
                _cache[type] = item;
            }

            GameObject instance = GameObject.Instantiate(item.Prefab.gameObject);
            instance.transform.localPosition = Vector3.zero;
            entity = instance.GetComponent<GameEntity>();
            if (entity != null)
                entity.Initialize(_objectId++, type);
            return entity as T;
        }

        public void ReturnEntity(IGameEntity entity)
        {
            entity.Owner.SetActive(false);
            entity.Owner.transform.parent = transform;
            Stack<IGameEntity> pool;
            if (!_pool.TryGetValue(entity.ObjectType, out pool))
            {
                pool = new Stack<IGameEntity>();
                _pool[entity.ObjectType] = pool;
            }
            pool.Push(entity);
        }
    }
}
