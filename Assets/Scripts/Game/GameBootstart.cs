
using System;
using System.Collections.Generic;
using Assets.Scripts.Common.EventAggregator;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Game.Common;
using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.EventSystem;
using Assets.Scripts.Game.UI.Controller;
using UnityEngine;

namespace Assets.Scripts.Game
{
	public class GameBootstart: IGameBootstart
	{
		private readonly IEventsManager _eventsManager;

		private readonly IInputManager _inputManager;

	    private readonly StartWindow.Factory _startWindow;

	    private readonly ScoreWindow.Factory _scoreWindow;

        public GameBootstart(IEventsManager eventsManager, IInputManager inputManager, StartWindow.Factory startWindow, ScoreWindow.Factory scoreWindow)
		{
			_eventsManager = eventsManager;
			_inputManager = inputManager;
		    _startWindow = startWindow;
		    _scoreWindow = scoreWindow;

            _inputManager.OnClick += OnSceneClick;
		}

		public void Startup()
		{
		    _scoreWindow.Create();
            _startWindow.Create();
		    
		    //_eventsManager.PublishEvent(new CreateGameEvent());
		}

		private void OnSceneClick(RaycastHit hit)
		{
			_eventsManager.PublishEvent(new SceneClickEvent(hit.point));
		}
	}
}
