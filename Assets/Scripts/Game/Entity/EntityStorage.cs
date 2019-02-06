using System.Collections.Generic;
using Assets.Scripts.Common.Entity;

namespace Assets.Scripts.Game.Entity
{
    public class EntityStorage
    {
        public HashSet<IGameEntity> Entities = new HashSet<IGameEntity>();
    }
}
