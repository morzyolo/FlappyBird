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

		_bird.ObstaclePassed += AddScore;
		_notifier.GameStarted += PrepareToStart;
		_notifier.GameOvered += HideScore;
		_notifier.GameRestarted += SetDefault;
		_notifier.GameQuited += Unsub;
		SetDefault();
	}

	public int GetCurrentScore() => _currentScore;

	private void SetDefault()
	{
		_currentScore = 0;
		_ui.Hide();
	}

	private void HideScore() => _ui.Hide();

	private void PrepareToStart()
	{
		_ui.Show();
		_ui.SetScore(_currentScore);
	}

	private void AddScore()
	{
		_currentScore++;
		_ui.SetScore(_currentScore);
	}

	private void Unsub()
	{
		_bird.ObstaclePassed -= AddScore;
		_notifier.GameStarted -= PrepareToStart;
		_notifier.GameOvered -= HideScore;
		_notifier.GameRestarted -= SetDefault;
		_notifier.GameQuited -= Unsub;
	}
}
