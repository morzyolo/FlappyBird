using System.Collections.Generic;

public class GroundsMover : ObjectsMover
{
	private readonly GameEventNotifier _notifier;

	public GroundsMover(List<MovingObject> grounds, GroundsDefaultSetter groundsSetter,
		GameEventNotifier notifier, Updater updater, MovingObjectsConfig config)
		: base(grounds, updater, groundsSetter, config)
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
