using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.Entity;
using Assets.Scripts.Game.Factory;
using Assets.Scripts.Game.Model;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Common.Entity
{
    public class GameEntity: MonoBehaviour, IGameEntity, IPoolable<IMemoryPool>
    {
        public int ObjectId { get; private set; }

        private static int _objectId;

        public EntityType ObjectType { get; protected set; }

        public GameObject Owner => gameObject;

        public void Initialize(int objectId, EntityType objectType)
        {
            ObjectId = objectId;
            ObjectType = objectType;
        }

        [Inject]
        public void Construct(EntityStorage entityStorage, EntityBehaiour behaiour)
        {
            _behaiour = behaiour;
            _entityStorage = entityStorage;
        }

        private EntityBehaiour _behaiour;

        private EntityStorage _entityStorage;

        public EntityBehaiour Behaiour => _behaiour;

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        public virtual void Enable()
        {
            _behaiour.SelectState(BehaiourState.None);
            _entityStorage.Entities.Add(this);
        }

        public virtual void Disable()
        {
            _behaiour.Clear();
            _entityStorage.Entities.Remove(this);
        }

        protected virtual void OnUpdate()
        {

        }

        private void Update()
        {
            _behaiour.Update();

            OnUpdate();
        }

        private IMemoryPool _pool;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            ObjectId = _objectId++;
            Enable();
        }

        public void OnDespawned()
        {
            Disable();
            _pool = null;
        }

        public void Destroy()
        {
            _pool?.Despawn(this);
        }
    }
}
