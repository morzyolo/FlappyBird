using UnityEngine;

public class BirdPreGameMover : IUpdateListener
{
	private readonly Bird _bird;
	private readonly Updater _updater;
	private readonly GameEventNotifier _notifier;

	private float _currentSinAngle = 0f;

	public BirdPreGameMover(Bird bird, Updater updater, GameEventNotifier notifier)
	{
		_bird = bird;
		_updater = updater;
		_notifier = notifier;

		_bird.MakeNonPhisical();
		_updater.AddListener(this);
		_notifier.GameStarted += StopMove;
	}

	public void Tick(float deltaTime)
	{
		if (_currentSinAngle > 360f)
			_currentSinAngle -= 360f;

		_currentSinAngle += deltaTime;
		_bird.transform.position = new Vector3(0f, Mathf.Sin(_currentSinAngle), 0f);
	}

	private void StopMove()
	{
		_notifier.GameStarted -= StopMove;

		_updater.RemoveListener(this);
		_bird.MakePhisical();
	}
}
