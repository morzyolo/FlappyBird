using System.Collections.Generic;

public class GroundsMover : ObjectsHorizontalMover
{
	private readonly GameEventNotifier _notifier;

	public GroundsMover(
		List<MovingObject> grounds,
		GroundsDefaultSetter groundsSetter,
		HorizontalMovingObjectsConfig config,
		Updater updater,
		GameEventNotifier notifier = null)
		: base(grounds, groundsSetter, config, updater)
	{
		_notifier = notifier;
		if (notifier != null)
			Sub();

		StartMoveObjects();
	}

	private void Sub()
	{
		_notifier.GameOvered += StopMoveObjects;
		_notifier.GameRestarted += StartMoveObjects;
		_notifier.GameQuited += Unsub;
	}

	private void Unsub()
	{
		_notifier.GameOvered -= StopMoveObjects;
		_notifier.GameRestarted -= StartMoveObjects;
		_notifier.GameQuited -= Unsub;
	}
}
