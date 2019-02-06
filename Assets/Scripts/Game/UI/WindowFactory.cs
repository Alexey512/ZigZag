using System;
using System.Collections.Generic;
using Assets.Scripts.Common.UI;
using Assets.Scripts.Common.UI.Controller;
using UnityEngine;

namespace Assets.Scripts.Game.UI
{
	[CreateAssetMenu(fileName = "WindowPrefabsAsset", menuName = "Game/WindowPrefabsAsset", order = 1)]
	public class WindowFactory: ScriptableObject, IWindowFactory
	{
		[Serializable]
		public class PrefabItem
		{
			public string Id;

			public WindowController Prefab;
		}

		[SerializeField]
		private List<PrefabItem> _Prefabs;

		private readonly Dictionary<Type, PrefabItem> _cache = new Dictionary<Type, PrefabItem>();

		public T CreateWindow<T>() where T : class, IWindowController
		{
			PrefabItem item;
			Type windowType = typeof(T);
			if (!_cache.TryGetValue(windowType, out item))
			{
				item = _Prefabs.Find(e => e.Prefab is T);
				if (item == null)
					return null;
				_cache[windowType] = item;
			}

			GameObject instance = GameObject.Instantiate(item.Prefab.Owner.gameObject);
			return instance.GetComponent<IWindowController>() as T;
		}
	}
}
