using System.Collections.Generic;
using Assets.Scripts.Common.Behaviour;
using Assets.Scripts.Game.Entity;
using UnityEngine;

namespace Assets.Scripts.Game.Model
{
    public class GameField
    {
        public HashSet<FieldElement> Elements = new HashSet<FieldElement>();

        public FieldElement LastElement;

        public Ball Ball;

        private IGameSettings _gameSettings;

        private FieldElement.Factory _elementsFactory;

        private Ball.Factory _ballFactory;

        public GameField(IGameSettings gameSettings, FieldElement.Factory elementsFactory, Ball.Factory ballFactory)
        {
            _gameSettings = gameSettings;
            _elementsFactory = elementsFactory;
            _ballFactory = ballFactory;
        }

        public void CreateStart()
        {
            Clear();

            int startSize = _gameSettings.StartSize;
            float tileSize = _gameSettings.TileSize;

            for (int i = 0; i < startSize; i++)
            {
                for (int j = 0; j < startSize; j++)
                {
                    _elementsFactory.Create(new FieldCoords(i, j));
                }
            }

            LastElement = _elementsFactory.Create(new FieldCoords(startSize / 2, startSize));
            LastElement.Entity.Behaiour.SelectState(BehaiourState.Create);


            Ball = _ballFactory.Create();
            var c = startSize * tileSize / 2;
            Ball.Position = new Vector3(c, 0.14f, c);
        }

        public void CreateNext()
        {
            if (LastElement == null)
                return;

            FieldCoords nextDir = Random.value > 0.5f ? FieldCoords.Top : FieldCoords.Right;
            FieldCoords nextPos = LastElement.Coords + nextDir;
            FieldElement next = _elementsFactory.Create(nextPos);
            next.Entity.Behaiour.SelectState(BehaiourState.Create);
            LastElement = next;
        }

        public void Clear()
        {
            var elements = new HashSet<FieldElement>(Elements);
            foreach (var element in elements)
            {
                element.Destroy();
            }
            Elements.Clear();
            LastElement = null;
            Ball?.Destroy();
            Ball = null;
        }
        
    }
}
