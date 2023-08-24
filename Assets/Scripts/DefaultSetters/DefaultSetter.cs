using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultSetter
{
	private readonly List<MovingObject> _objects;
	private readonly GameEventNotifier _notifier;

	private readonly float _startX;
	private readonly float _xOffset;

	public DefaultSetter(List<MovingObject> objects, HorizontalMovingObjectsConfig config, GameEventNotifier notifier)
	{
		_objects = objects;
		_notifier = notifier;

		_startX = config.StartX;
		_xOffset = config.XOffset;

		_notifier.GameRestarted += Place;
		_notifier.GameQuited += Unsub;
	}

	public abstract float GetHeight();

	protected void Place()
	{
		var spawnPosition = new Vector3(_startX, 0f, 0f);

		for (int i = 0; i < _objects.Count; i++)
		{
			spawnPosition.y = GetHeight();
			_objects[i].transform.position = spawnPosition;
			_objects[i].Reset();
			spawnPosition.x += _xOffset;
		}
	}

	private void Unsub()
	{
		_notifier.GameRestarted -= Place;
		_notifier.GameQuited -= Unsub;
	}
}
