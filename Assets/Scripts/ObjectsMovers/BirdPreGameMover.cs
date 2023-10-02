public class BirdPreGameMover : ObjectSinusMover
{
	private readonly Bird _bird;
	private readonly GameEventNotifier _notifier;

	public BirdPreGameMover(
		Bird bird,
		GameEventNotifier notifier,
		BirdConfig config,
		Updater updater)
		: base(bird.transform, config.SinusMovingObjectsConfig, updater)
	{
		_bird = bird;
		_notifier = notifier;

		_notifier.GameRestarted += Reset;
		_notifier.GameStarted += StopMove;
		_notifier.AddDisposable(this);
		StartMove();
	}

	public override void Dispose()
	{
		_notifier.GameRestarted -= Reset;
		_notifier.GameStarted -= StopMove;
	}

	private void StartMove()
	{
		_bird.MakeNonPhisical();
		StartMoveObjects();
	}

	private void Reset()
	{
		_bird.Reset();
		StartMove();
	}

	private void StopMove()
	{
		StopMoveObjects();
		_bird.MakePhisical();
	}
}
