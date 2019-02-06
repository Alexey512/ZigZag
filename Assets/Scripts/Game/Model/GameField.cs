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

        private IGameSettings _gameSettings;

        private FieldElement.Factory _elementsFactory;

        public GameField(IGameSettings gameSettings, FieldElement.Factory elementsFactory)
        {
            _gameSettings = gameSettings;
            _elementsFactory = elementsFactory;
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
        }
        
    }
}
