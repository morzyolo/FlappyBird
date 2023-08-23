public class GameResult
{
	private readonly string _menuSceneName = "Menu";

	private readonly Score _score;
	private readonly EndGameUI _ui;
	private readonly GameRestarter _restarter;
	private readonly GameEventNotifier _notifier;
	private readonly SceneChanger _sceneChanger;

	public GameResult(Score score, EndGameUI endGameUI, GameRestarter restarter, GameEventNotifier notifier, SceneChanger sceneChanger)
	{
		_score = score;
		_ui = endGameUI;
		_restarter = restarter;
		_notifier = notifier;
		_sceneChanger = sceneChanger;

		_ui.Initialize(this);

		_notifier.GameOvered += ShowResult;
		_notifier.GameRestarted += Hide;
		_notifier.GameQuited += Unsub;
		Hide();
	}

	public void RestartGame() => _restarter.Restart();

	public async void ChangeScene() => await _sceneChanger.ChangeSceneAsync(_menuSceneName);

	private void ShowResult()
	{
		int currentScore = _score.GetCurrentScore();

		_ui.Show();
		_ui.SetCurrentScore(currentScore);
	}

	private void Hide() => _ui.Hide();

	private void Unsub()
	{
		_notifier.GameOvered -= ShowResult;
		_notifier.GameRestarted -= Hide;
		_notifier.GameQuited -= Unsub;
	}
}
