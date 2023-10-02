using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDefaultSetter : DefaultSetter
{
	private readonly GameEventNotifier _notifier;

	private readonly float _maxHeight;
	private readonly float _minHeight;

	public ObstaclesDefaultSetter(
		List<MovingObject> obstacles,
		HorizontalMovingObjectsConfig config,
		GameEventNotifier notifier = null)
		: base(obstacles, config)
	{
		_maxHeight = config.MaxHeight;
		_minHeight = config.MinHeight;

		_notifier = notifier;

		if (notifier != null)
		{
			_notifier.GameRestarted += Place;
			_notifier.AddDisposable(this);
		}

		Place();
	}

	public override float GetHeight() => Random.Range(_minHeight, _maxHeight);

	public override void Dispose()
	{
		_notifier.GameRestarted -= Place;
	}
}
