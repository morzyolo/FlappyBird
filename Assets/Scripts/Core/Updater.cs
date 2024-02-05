using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core
{
	public class Updater : ITickable
	{
		private readonly List<IUpdateListener> _updateListeners = new();

		public void Tick()
		{
			foreach (var listener in _updateListeners)
				listener.Tick(Time.deltaTime);
		}

		public void AddListener(IUpdateListener listener) => _updateListeners.Add(listener);

		public void RemoveListener(IUpdateListener listener) => _updateListeners.Remove(listener);
	}
}
