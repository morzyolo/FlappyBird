using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
	private readonly List<IUpdateListener> _updateListeners = new();

	private void Update()
	{
		foreach (var listener in _updateListeners)
			listener.Tick(Time.deltaTime);
	}

	public void AddListener(IUpdateListener listener) => _updateListeners.Add(listener);

	public void RemoveListener(IUpdateListener listener) => _updateListeners.Remove(listener);
}
