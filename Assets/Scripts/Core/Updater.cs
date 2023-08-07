using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
	private readonly List<IUpdateListener> _fixedUpdateListeners = new();

	private void Update()
	{
		foreach (var listener in _fixedUpdateListeners)
			listener.Tick(Time.deltaTime);
	}

	public void AddListener(IUpdateListener listener) => _fixedUpdateListeners.Add(listener);

	public void RemoveListener(IUpdateListener listener) => _fixedUpdateListeners.Remove(listener);
}
