using System.Collections.Generic;
using UnityEngine;

public class ObjectsHorizontalMover : ObjectsMover
{
	private readonly List<MovingObject> _objects;
	private readonly DefaultSetter _setter;

	private readonly float _endX;
	private readonly float _xOffset;
	private readonly float _moveSpeed;

	public ObjectsHorizontalMover(
		List<MovingObject> objects,
		DefaultSetter setter,
		HorizontalMovingObjectsConfig config,
		Updater updater)
		: base(updater)
	{
		_objects = objects;
		_setter = setter;

		_endX = config.EndX;
		_xOffset = config.XOffset;
		_moveSpeed = config.MoveSpeed;
	}

	public override void Tick(float deltaTime)
	{
		for (int i = 0; i < _objects.Count; i++)
		{
			_objects[i].transform.Translate(_moveSpeed * deltaTime * Vector3.left);

			if (_objects[i].transform.position.x < _endX)
			{
				float newX = _objects[i].transform.position.x + _objects.Count * _xOffset;
				float height = _setter.GetHeight();
				_objects[i].SetPosition(new Vector3(newX, height, 0f));
			}
		}
	}
}
