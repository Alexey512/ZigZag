using System;
using System.Collections.Generic;
using Assets.Scripts.Common.EventAggregator;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.Model;
using Assets.Scripts.Game.Units;
using UnityEngine;

namespace Assets.Scripts.Game.Events
{
    public sealed class SceneClickEvent: GameEvent<SceneClickEvent>
    {
        public Vector3 Point;

        public SceneClickEvent(Vector3 point)
        {
            Point = point;
        }
    }

    public sealed class SceneClickHandler: SceneClickEvent.IEventHandler
	{
		private readonly IGameScene _gameScene;

		private readonly IEventsManager _publisher;

		public SceneClickHandler(IGameScene gameScene, IEventsManager publisher)
		{
			_gameScene = gameScene;
			_publisher = publisher;
		}

		public void OnEvent(SceneClickEvent data)
		{
			Debug.Log("CLICK CLICK!!!");
		}
	}
}
