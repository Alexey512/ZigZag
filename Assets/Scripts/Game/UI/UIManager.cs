using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Common.EventAggregator;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.UI.Context;
using Assets.Scripts.Common.UI.Controller;
using Assets.Scripts.Game.EventSystem;
using UnityEngine;

namespace Assets.Scripts.Game.UI
{
	public class UIManager: IUIManager
	{
		private readonly IWindowRoot _root;

		private readonly IWindowFactory _windowFactory;

		private readonly IEventsManager _publisher;

		public UIManager(IWindowRoot root, IWindowFactory windowFactory, IEventsManager publisher)
		{
			_windowFactory = windowFactory;
			_publisher = publisher;
			_root = root;
		}


		//private readonly Stack<IWindowController> _windows = new Stack<IWindowController>();

		private IWindowController _currentWindow;

		public void ShowWindow<T>(CustomObject data) where T : class, IWindowController
		{
			var window = _windowFactory.CreateWindow<T>();
			if (window == null)
				return;

			CloseWindow();

			IWindowContext context = new WindowContext(this, _publisher, data);
			window.Initialize(context);
			window.Owner.parent = _root.Root;
			window.Owner.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		public void CloseWindow(IWindowController window)
		{

		}

		public void CloseWindow()
		{
			if (_currentWindow == null)
				return;

			//_currentWindow.Owner.transform.parent = null;
		}


	}
}
