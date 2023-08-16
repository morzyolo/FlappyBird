using UnityEngine;

public class BirdPreGameMover : IUpdateListener
{
	private readonly Bird _bird;
	private readonly Updater _updater;
	private readonly GameEventNotifier _notifier;

	private readonly float _yOffset;
	private readonly float _speed;

	private float _currentSinAngle;

	public BirdPreGameMover(Bird bird, Updater updater, BirdConfig config, GameEventNotifier notifier)
	{
		_bird = bird;
		_updater = updater;
		_notifier = notifier;

		_yOffset = config.YOffset;
		_speed = config.PreGameSpeed;

		_notifier.GameRestarted += Reset;
		_notifier.GameStarted += StopMove;
		_notifier.GameQuited += Unsub;
		StartMove();
	}

	public void Tick(float deltaTime)
	{
		if (_currentSinAngle > 360f)
			_currentSinAngle -= 360f;

		_currentSinAngle += deltaTime;
		var currentPosition = _bird.transform.position;
		currentPosition.y = _yOffset * Mathf.Sin(_currentSinAngle * _speed);
		_bird.transform.position = currentPosition;
	}

	private void StartMove()
	{
		_currentSinAngle = 0f;

		_bird.MakeNonPhisical();
		_updater.AddListener(this);
	}

	private void Reset()
	{
		_bird.Reset();
		StartMove();
	}

	private void StopMove()
	{
		_updater.RemoveListener(this);
		_bird.MakePhisical();
	}

	private void Unsub()
	{
		_notifier.GameRestarted += Reset;
		_notifier.GameStarted -= StopMove;
		_notifier.GameQuited -= Unsub;
	}
}
