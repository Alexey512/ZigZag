using System;
using Assets.Scripts.Common.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Actions
{
    public class TriggerListener: MonoBehaviour
    {
        public event Action<IGameEntity> TriggerEnter;

        public event Action<IGameEntity> TriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            var entity = other.GetComponentInParent<IGameEntity>();
            if (entity != null && TriggerEnter != null)
                TriggerEnter?.Invoke(entity);
        }

        private void OnTriggerExit(Collider other)
        {
            var entity = other.GetComponentInParent<IGameEntity>();
            if (entity != null && TriggerExit != null)
                TriggerExit?.Invoke(entity);
        }
    }
}
