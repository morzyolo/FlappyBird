using System.Collections.Generic;

public class ObstaclesMover : ObjectsHorizontalMover
{
	private readonly GameEventNotifier _notifier;

	public ObstaclesMover(
		GameEventNotifier notifier,
		List<MovingObject> obstacles,
		ObstaclesDefaultSetter obstaclesSetter,
		HorizontalMovingObjectsConfig config,
		Updater updater)
		: base(obstacles, obstaclesSetter, config, updater)
	{
		_notifier = notifier;

		_notifier.GameStarted += StartMoveObjects;
		_notifier.GameOvered += StopMoveObjects;
		_notifier.AddDisposable(this);
	}

	public override void Dispose()
	{
		_notifier.GameStarted -= StartMoveObjects;
		_notifier.GameOvered -= StopMoveObjects;
	}
}
