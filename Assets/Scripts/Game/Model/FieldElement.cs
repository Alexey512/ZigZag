using System.Collections.Generic;
using Assets.Scripts.Common.Entity;
using Assets.Scripts.Game.Entity;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Model
{
    public class FieldElement: IPoolable<FieldCoords, IMemoryPool>
    {
        public IGameEntity Entity { get; private set; }

        public FieldCoords Coords;

        public List<IGameEntity> Rewards = new List<IGameEntity>();

        private Tile _tile;

        private Crystal _crystal;

        private readonly Tile.Factory _tileFactory;

        private readonly Crystal.Factory _crystalFactory;

        private readonly GameField _field;

        private IGameSettings _gameSettings;

        public FieldElement(IGameSettings gameSettings, GameField field, Tile.Factory tileFactory, Crystal.Factory crystalFactory)
        {
            _field = field;
            _gameSettings = gameSettings;
            _tileFactory = tileFactory;
            _crystalFactory = crystalFactory;
        }

        private IMemoryPool _pool;

        public void OnDespawned()
        {
            Entity.Destroy();
            Entity = null;
            _crystal?.Destroy();
            _crystal = null;
            _field.Elements.Remove(this);
        }

        public void OnSpawned(FieldCoords coords, IMemoryPool pool)
        {
            _pool = pool;
            Coords = coords;
            float tileSize = _gameSettings.TileSize;
            Entity = _tileFactory.Create();
            Entity.Position = new Vector3(coords.X * tileSize, 0, coords.Y * tileSize);

            if (Random.value > _gameSettings.CrystalChance)
            {
                _crystal = _crystalFactory.Create();
                _crystal.Position = new Vector3(coords.X * tileSize + Random.value * tileSize, 0, coords.Y * tileSize + Random.value * tileSize);
            }

            _field.Elements.Add(this);
        }

        public void Destroy()
        {
            _pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<FieldCoords, FieldElement>
        {
        }
    }
}
