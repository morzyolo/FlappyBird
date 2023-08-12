public class GameResult
{
	private readonly Score _score;
	private readonly EndGameUI _ui;
	private readonly GameEventNotifier _notifier;

	public GameResult(Score score, EndGameUI endGameUI, GameEventNotifier notifier)
	{
		_score = score;
		_ui = endGameUI;
		_notifier = notifier;

		_ui.Hide();
		_notifier.GameOvered += ShowResult;
	}

	private void ShowResult()
	{
		_notifier.GameOvered -= ShowResult;

		int currentScore = _score.GetCurrentScore();

		_ui.Show();
		_ui.SetCurrentScore(currentScore);
	}
}
