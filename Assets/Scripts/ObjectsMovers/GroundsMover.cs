using System.Collections.Generic;

public class GroundsMover : ObjectsHorizontalMover
{
	private readonly GameEventNotifier _notifier;

	public GroundsMover(
		GameEventNotifier notifier,
		List<MovingObject> grounds,
		GroundsDefaultSetter groundsSetter,
		HorizontalMovingObjectsConfig config,
		Updater updater)
		: base(grounds, groundsSetter, config, updater)
	{
		_notifier = notifier;

		_notifier.GameOvered += StopMoveObjects;
		_notifier.GameRestarted += StartMoveObjects;
		_notifier.GameQuited += Unsub;
		StartMoveObjects();
	}

	private void Unsub()
	{
		_notifier.GameOvered -= StopMoveObjects;
		_notifier.GameRestarted -= StartMoveObjects;
		_notifier.GameQuited -= Unsub;
	}
}
