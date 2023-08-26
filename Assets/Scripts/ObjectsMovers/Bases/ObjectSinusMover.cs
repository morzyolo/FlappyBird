using UnityEngine;

public class ObjectSinusMover : ObjectsMover
{
	private readonly Transform _obj;

	private readonly float _startY;
	private readonly float _yOffset;
	private readonly float _speed;

	private readonly float _period;

	private float _currentSinAngle = 0f;

	public ObjectSinusMover(
		Transform obj,
		SinusMovingObjectsConfig config,
		Updater updater)
		: base(updater)
	{
		_obj = obj;

		_startY = obj.position.y;
		_yOffset = config.YOffset;
		_speed = config.Speed;

		_period = Mathf.PI * 2 / Mathf.Abs(_speed);
	}

	public override void Tick(float deltaTime)
	{
		_currentSinAngle += deltaTime;

		if (_currentSinAngle > _period)
			_currentSinAngle -= _period;

		Vector3 newPosition = _obj.position;
		newPosition.y = _startY + _yOffset * Mathf.Sin(_currentSinAngle * _speed);
		_obj.position = newPosition;
	}
}
