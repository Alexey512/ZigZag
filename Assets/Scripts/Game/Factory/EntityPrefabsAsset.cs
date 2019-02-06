using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Factory
{
    [CreateAssetMenu(fileName = "EntityPrefabsAsset", menuName = "Game/EntityPrefabsAsset", order = 0)]
    public class EntityPrefabsAsset : ScriptableObject
    {
        [Serializable]
        public class PrefabItem
        {
            public EntityType Type;

            public GameEntity Prefab;
        }

        [SerializeField]
        private List<PrefabItem> _prefabs = new List<PrefabItem>();

        public PrefabItem GetItem(EntityType type)
        {
            return _prefabs.Find(p => p.Type == type);
        }
    }

}
