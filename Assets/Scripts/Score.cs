public class Score
{
	private readonly Bird _bird;
	private readonly ScoreUI _ui;
	private readonly GameEventNotifier _notifier;

	private int _currentScore = 0;

	public Score(Bird bird, ScoreUI ui, GameEventNotifier notifier)
	{
		_bird = bird;
		_ui = ui;
		_notifier = notifier;

		_ui.HideScore();
		_notifier.GameStarted += PrepareToStart;
	}

	private void PrepareToStart()
	{
		_notifier.GameStarted -= PrepareToStart;

		_ui.ShowScore();
		_ui.SetScore(_currentScore);
		_bird.PipePassed += AddScore;
	}

	private void AddScore()
	{
		_currentScore++;
		_ui.SetScore(_currentScore);
	}
}
