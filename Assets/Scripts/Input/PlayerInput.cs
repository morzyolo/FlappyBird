public class PlayerInput
{
	private readonly Bird _bird;
	private readonly InputPanel _inputPanel;
	private readonly GameEventNotifier _notifier;

	public PlayerInput(Bird bird, InputPanel inputPanel, GameEventNotifier notifier)
	{
		_bird = bird;
		_inputPanel = inputPanel;
		_notifier = notifier;

		_notifier.GameStarted += StartAcceptingInput;
		_notifier.GameOvered += StopAcceptingInput;
		_notifier.GameQuited += Unsub;
	}

	private void Flap() => _bird.Flap();

	private void StartAcceptingInput() => _inputPanel.Clicked += Flap;

	private void StopAcceptingInput() => _inputPanel.Clicked -= Flap;

	private void Unsub()
	{
		_notifier.GameStarted -= StartAcceptingInput;
		_notifier.GameOvered -= StopAcceptingInput;
		_notifier.GameQuited -= Unsub;
	}
}
