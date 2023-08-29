using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameResult
{
	private readonly string _menuSceneName = "Menu";
	private readonly float _gameOverTextYModifier = 50f;
	private readonly float _uiSpeed = 1.5f;

	private readonly float _panelShowYPosition = 200f;
	private readonly float _panelHideYPosition = -1500f;

	private readonly Score _score;
	private readonly EndGameUI _ui;
	private readonly GameRestarter _restarter;
	private readonly SceneChanger _sceneChanger;
	private readonly GameEventNotifier _notifier;
	private readonly PlayerStatsDataHandler _statsHandler;

	private int _bestScore = 0;

	public GameResult(Score score,
		EndGameUI endGameUI,
		GameRestarter restarter,
		SceneChanger sceneChanger,
		GameEventNotifier notifier,
		PlayerStatsDataHandler playerStatsDataHandler)
	{
		_score = score;
		_ui = endGameUI;
		_restarter = restarter;
		_sceneChanger = sceneChanger;
		_notifier = notifier;
		_statsHandler = playerStatsDataHandler;

		_bestScore = _statsHandler.Stats.MaxScore;

		_ui.Initialize(this);

		_notifier.GameOvered += ShowResult;
		_notifier.GameRestarted += Hide;
		_notifier.GameQuited += Unsub;
		Hide();
	}

	public void RestartGame() => _restarter.Restart();

	public async void ChangeScene() => await _sceneChanger.ChangeSceneAsync(_menuSceneName);

	private async void ShowResult()
	{
		await ShowGameOverText();
		_ui.SetBestScore(_bestScore);
		await ShowPanel();

		int currentScore = _score.GetCurrentScore();
		await IncreaceToCurrentScore(currentScore);

		CheckCurrentScore(currentScore);

		_ui.ShowButtons();
	}

	private async UniTask ShowGameOverText()
	{
		RectTransform text = _ui.GetGameOverTextRectTransform();
		float t = 0;

		Vector3 startTextPosition = text.position;

		while (t < 1)
		{
			_ui.SetGameOverTextAlpha(t);
			Vector3 newTextPosition = startTextPosition;
			newTextPosition.y += CalculateY(t) * _gameOverTextYModifier;
			text.position = newTextPosition;
			t += Time.deltaTime * _uiSpeed;

			await UniTask.Yield();
		}

		_ui.SetGameOverTextAlpha(1);
	}

	private float CalculateY(float x) => 4 * x * (1 - x);

	private async UniTask ShowPanel()
	{
		RectTransform panel = _ui.GetPanelRectTransform();

		Vector3 startPosition = panel.localPosition;
		startPosition.y = _panelHideYPosition;

		Vector3 endPosition = panel.localPosition;
		endPosition.y = _panelShowYPosition;

		float t = 0;

		while (t < 1)
		{
			panel.localPosition = Vector3.Lerp(startPosition, endPosition, t);
			t += Time.deltaTime * _uiSpeed;

			await UniTask.Yield();
		}

		panel.localPosition = endPosition;
	}

	private async UniTask IncreaceToCurrentScore(int currentScore)
	{
		_ui.SetCurrentScore(0);

		float t = 0;
		int score = 0;
		while (score < currentScore)
		{
			t += Time.deltaTime;
			score = CalculateScore(t);
			_ui.SetCurrentScore(score);

			await UniTask.Yield();
		}
	}

	private int CalculateScore(float x) => (int)(x * x);

	private void CheckCurrentScore(int currentScore)
	{
		if (currentScore > _bestScore)
		{
			_bestScore = currentScore;
			_ui.ShowNewBestScore();
			_ui.SetBestScore(_bestScore);
			SaveScore();
		}
	}

	private void SaveScore()
	{
		PlayerStatsData statsData = _statsHandler.Stats;
		statsData.MaxScore = _bestScore;
		_statsHandler.SaveStats(statsData);
	}

	private void Hide()
	{
		_ui.SetPanelPosition(_panelHideYPosition);
		_ui.SetGameOverTextAlpha(0);
		_ui.Hide();
	}

	private void Unsub()
	{
		_notifier.GameOvered -= ShowResult;
		_notifier.GameRestarted -= Hide;
		_notifier.GameQuited -= Unsub;
	}
}
