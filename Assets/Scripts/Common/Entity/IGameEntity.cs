using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.Factory;
using UnityEngine;

namespace Assets.Scripts.Common.Entity
{
    public interface IGameEntity
    {
        EntityType ObjectType { get; }

        int ObjectId { get; }

        GameObject Owner { get; }

        void Initialize(int objectId, EntityType objectType);

        Vector3 Position { get; set; }

        Quaternion Rotation { get; set; }

        EntityBehaiour Behaiour { get; }

        void Enable();

        void Disable();

        void Destroy();
    }
}
