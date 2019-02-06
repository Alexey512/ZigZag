using System;
using System.Collections.Generic;
using Assets.Scripts.Common.Actions;
using UnityEngine;

namespace Game.Actions
{
	public interface IUpdateManager
	{
		void Register(IUpdatable obj);

		void UnRegister(IUpdatable obj);

		void UnRegisterAll();
	}

	public class UpdateManager: /*Singleton<UpdateManager>,*/ IUpdateManager
	{
		private readonly HashSet<IUpdatable> _objects = new HashSet<IUpdatable>();

		private readonly HashSet<IUpdatable> _addedObjects = new HashSet<IUpdatable>();

		private readonly HashSet<IUpdatable> _removedObjects = new HashSet<IUpdatable>();

		private const int MaxCallsPerFrame = 2000;

		private int _lastIndex = 0;

		public void Register(IUpdatable obj)
		{
			_addedObjects.Add(obj);
		}

		public void UnRegister(IUpdatable obj)
		{
			_removedObjects.Remove(obj);
		}

		public void UnRegisterAll()
		{
			_objects.Clear();
		}

		private void Update()
		{
			float delta = Time.deltaTime;
			foreach (var obj in _objects)
			{
				if (!_removedObjects.Contains(obj) || _addedObjects.Contains(obj))
					obj.Update(delta);
			}

			foreach (var obj in _addedObjects)
			{
				_objects.Add(obj);
			}

			foreach (var obj in _removedObjects)
			{
				_objects.Remove(obj);
			}
		}
	}
}
