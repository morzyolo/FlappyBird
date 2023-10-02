using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultSetter : IDisposable
{
	private readonly List<MovingObject> _objects;

	private readonly float _startX;
	private readonly float _xOffset;

	public DefaultSetter(List<MovingObject> objects, HorizontalMovingObjectsConfig config)
	{
		_objects = objects;

		_startX = config.StartX;
		_xOffset = config.XOffset;
	}

	public abstract float GetHeight();

	public abstract void Dispose();

	protected void Place()
	{
		var spawnPosition = new Vector3(_startX, 0f, 0f);

		for (int i = 0; i < _objects.Count; i++)
		{
			spawnPosition.y = GetHeight();
			_objects[i].SetPosition(spawnPosition);
			_objects[i].Reset();
			spawnPosition.x += _xOffset;
		}
	}
}
