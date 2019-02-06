
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
		private readonly IUIManager _uiManager;

		private readonly IEventsManager _eventsManager;

		private readonly IInputManager _inputManager;

		public GameBootstart(IUIManager uiManager, IEventsManager eventsManager, IInputManager inputManager)
		{
			_uiManager = uiManager;
			_eventsManager = eventsManager;
			_inputManager = inputManager;

			_inputManager.OnClick += OnSceneClick;
		}

		public void Startup()
		{
			_uiManager.ShowWindow<LeftPanelWindow>(null);

		    _eventsManager.PublishEvent(new CreateGameEvent());
        }

		private void OnSceneClick(RaycastHit hit)
		{
			_eventsManager.PublishEvent(new SceneClickEvent(hit.point));
		}
	}
}
