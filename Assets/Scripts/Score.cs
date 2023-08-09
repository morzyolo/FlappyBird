public class Score
{
	private readonly Bird _bird;
	private readonly ScoreUI _ui;

	private int _currentScore = 0;

	public Score(Bird bird, ScoreUI ui)
	{
		_bird = bird;
		_ui = ui;

		_ui.SetScore(_currentScore);
		_bird.PipePassed += AddScore;
	}

	private void AddScore()
	{
		_currentScore++;
		_ui.SetScore(_currentScore);
	}
}
