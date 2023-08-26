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
			Sub();

		Place();
	}

	public override float GetHeight() => Random.Range(_minHeight, _maxHeight);

	private void Sub()
	{
		_notifier.GameRestarted += Place;
		_notifier.GameQuited += Unsub;
	}

	private void Unsub()
	{
		_notifier.GameRestarted -= Place;
		_notifier.GameQuited -= Unsub;
	}
}
