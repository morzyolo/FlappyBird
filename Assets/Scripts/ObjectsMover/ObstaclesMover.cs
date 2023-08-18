using System.Collections.Generic;

public class ObstaclesMover : ObjectsMover
{
	private readonly GameEventNotifier _notifier;

	public ObstaclesMover(List<MovingObject> obstacles, ObstaclesDefaultSetter obstaclesSetter,
		GameEventNotifier notifier, Updater updater, MovingObjectsConfig config)
		: base(obstacles, updater, obstaclesSetter, config)
	{
		_notifier = notifier;

		_notifier.GameStarted += StartMoveObjects;
		_notifier.GameOvered += StopMoveObjects;
		_notifier.GameQuited += Unsub;
	}

	private void Unsub()
	{
		_notifier.GameStarted -= StartMoveObjects;
		_notifier.GameOvered -= StopMoveObjects;
		_notifier.GameQuited -= Unsub;
	}
}
