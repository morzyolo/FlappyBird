using UnityEngine;

public class PlayerInput : IUpdateListener
{
	private readonly Bird _bird;
	private readonly Updater _updater;
	private readonly GameEventNotifier _notifier;

	public PlayerInput(Bird bird, Updater updater, GameEventNotifier notifier)
	{
		_bird = bird;
		_updater = updater;
		_notifier = notifier;

		_notifier.GameStarted += StartAcceptingInput;
		_notifier.GameOvered += StopAcceptingInput;
		_notifier.GameQuited += Unsub;
	}

	public void Tick(float deltaTime)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			_bird.Flap();
	}

	private void StartAcceptingInput() => _updater.AddListener(this);

	private void StopAcceptingInput() => _updater.RemoveListener(this);

	private void Unsub()
	{
		_notifier.GameStarted -= StartAcceptingInput;
		_notifier.GameOvered -= StopAcceptingInput;
		_notifier.GameQuited -= Unsub;
	}
}
