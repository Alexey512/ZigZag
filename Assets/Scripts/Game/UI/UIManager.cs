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
	public class UIManager
	{
		private readonly IWindowRoot _root;

	    private IWindowController _current;

		public UIManager(IWindowRoot root)
		{
			_root = root;
		}

		public void AddWindow(IWindowController window)
		{
			CloseWindow();
            if (_current == window)
                return;

		    _current = window;
		    //_current.Owner.parent = _root.Root;
            //var rectTransform = _current.Owner.GetComponent<RectTransform>();
		    //rectTransform.anchoredPosition = Vector2.zero;
		    //rectTransform.localScale = Vector3.one;
        }

		public void RemoveWindow(IWindowController window)
		{
		    if (_current == window)
		    {
		        _current.Hide();
		    }
        }

		public void CloseWindow()
		{
		    _current?.Hide();
		    _current = null;
		}
	}
}
