using System.Collections.Generic;
using UnityEngine;

public class ObjectSinusMover : ObjectsMover
{
	private readonly List<Transform> _objects;

	private readonly float _startY;
	private readonly float _yOffset;
	private readonly float _speed;

	private readonly float _period;

	private float _currentSinAngle = 0f;

	public ObjectSinusMover(
		List<Transform> objects,
		SinusMovingObjectsConfig config,
		Updater updater)
		: base(updater)
	{
		_objects = objects;

		_startY = config.StartY;
		_yOffset = config.YOffset;
		_speed = config.Speed;

		_period = Mathf.PI * 2 / Mathf.Abs(_yOffset);
	}

	public override void Tick(float deltaTime)
	{
		_currentSinAngle += deltaTime;

		if (_currentSinAngle > _period)
			_currentSinAngle -= _period;

		float currentY = _startY + _yOffset * Mathf.Sin(_currentSinAngle * _speed);

		for (int i = 0; i < _objects.Count; ++i)
		{
			Vector3 newPosition = _objects[i].position;
			newPosition.y = currentY;
			_objects[i].transform.position = newPosition;
		}
	}
}
