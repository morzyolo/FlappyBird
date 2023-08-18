using System.Collections.Generic;
using UnityEngine;

public class ObjectsMover : IUpdateListener
{
	private readonly List<MovingObject> _objects;
	private readonly Updater _updater;
	private readonly DefaultSetter _setter;

	private readonly float _endX;
	private readonly float _xOffset;
	private readonly float _moveSpeed;

	public ObjectsMover(List<MovingObject> objects, Updater updater, DefaultSetter setter, MovingObjectsConfig config)
	{
		_objects = objects;
		_updater = updater;
		_setter = setter;

		_endX = config.EndX;
		_xOffset = config.XOffset;
		_moveSpeed = config.MoveSpeed;
	}

	public void Tick(float deltaTime)
	{
		for (int i = 0; i < _objects.Count; i++)
		{
			_objects[i].transform.Translate(_moveSpeed * deltaTime * Vector3.left);

			if (_objects[i].transform.position.x < _endX)
			{
				float newX = _objects[i].transform.position.x + _objects.Count * _xOffset;
				float height = _setter.GetHeight();
				_objects[i].transform.position = new Vector3(newX, height, 0f);
			}
		}
	}

	protected void StartMoveObjects() => _updater.AddListener(this);

	protected void StopMoveObjects() => _updater.RemoveListener(this);
}
