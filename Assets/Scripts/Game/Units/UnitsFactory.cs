using System;
using System.Collections.Generic;
using Assets.Scripts.Common.UI.Controller;
using UnityEngine;

namespace Assets.Scripts.Game.Units
{
	[CreateAssetMenu(fileName = "UnitsPrefabsAsset", menuName = "Game/UnitsPrefabsAsset", order = 0)]
	public class UnitsFactory: ScriptableObject, IUnitsFactory
	{
		[Serializable]
		public class PrefabItem
		{
			public string Id;

			public GameObject Prefab;
		}

		[SerializeField]
		private Unit _unitPrefab;

		[SerializeField]
		private List<PrefabItem> _prefabs;

		private readonly Dictionary<string, PrefabItem> _cache = new Dictionary<string, PrefabItem>();

		public T CreateUnit<T>(string unitId) where T : class, IUnit
		{
			PrefabItem item;
			if (!_cache.TryGetValue(unitId, out item))
			{
				item = _prefabs.Find(e => e.Id == unitId);
				if (item == null)
					return null;
				_cache[unitId] = item;
			}

			GameObject container = GameObject.Instantiate(_unitPrefab.gameObject);
			GameObject instance = GameObject.Instantiate(item.Prefab);
			instance.transform.parent = container.transform;
			instance.transform.localPosition = Vector3.zero;
			return container.GetComponent<IUnit>() as T;
		}
	}
}
