using UnityEngine;

public class BirdPreGameMover : IUpdateListener
{
	private readonly Bird _bird;
	private readonly Updater _updater;
	private readonly GameEventNotifier _notifier;

	private float _yOffset;
	private float _speed;

	private float _currentSinAngle = 0f;

	public BirdPreGameMover(Bird bird, Updater updater, BirdConfig config, GameEventNotifier notifier)
	{
		_bird = bird;
		_updater = updater;
		_notifier = notifier;

		ApplyConfig(config);

		_bird.MakeNonPhisical();
		_updater.AddListener(this);
		_notifier.GameStarted += StopMove;
	}

	private void ApplyConfig(BirdConfig config)
	{
		_yOffset = config.YOffset;
		_speed = config.PreGameSpeed;
	}

	public void Tick(float deltaTime)
	{
		if (_currentSinAngle > 360f)
			_currentSinAngle -= 360f;

		_currentSinAngle += deltaTime;
		_bird.transform.position = new Vector3(0f, _yOffset * Mathf.Sin(_currentSinAngle * _speed), 0f);
	}

	private void StopMove()
	{
		_notifier.GameStarted -= StopMove;

		_updater.RemoveListener(this);
		_bird.MakePhisical();
	}
}
