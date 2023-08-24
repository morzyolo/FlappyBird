using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDefaultSetter : DefaultSetter
{
	private readonly float _maxHeight;
	private readonly float _minHeight;

	public ObstaclesDefaultSetter(List<MovingObject> obstacles, HorizontalMovingObjectsConfig config,
		GameEventNotifier notifier)
		: base(obstacles, config, notifier)
	{
		_maxHeight = config.MaxHeight;
		_minHeight = config.MinHeight;
		Place();
	}

	public override float GetHeight() => Random.Range(_minHeight, _maxHeight);
}
