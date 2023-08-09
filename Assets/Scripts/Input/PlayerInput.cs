using UnityEngine;

public class PlayerInput : MonoBehaviour, IUpdateListener
{
	private Bird _bird;
	private Updater _updater;
	private GameEventNotifier _notifier;

	public void Initialize(Bird bird, Updater updater, GameEventNotifier notifier)
	{
		_bird = bird;
		_updater = updater;
		_notifier = notifier;

		_updater.AddListener(this);
		notifier.GameOvered += StopAcceptingInput;
	}

	public void Tick(float deltaTime)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			_bird.Flap();
	}

	private void StopAcceptingInput() => _updater.RemoveListener(this);

	private void OnDisable()
	{
		_notifier.GameOvered -= StopAcceptingInput;
	}
}
