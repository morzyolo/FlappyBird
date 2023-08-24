using System.Threading.Tasks;
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

	private async void ShowResult()
	{
		await ShowGameOverText();
		await ShowPanel();
		await IncreaceCurrentScore();

		_ui.ShowButtons();
	}

	private async Task ShowGameOverText()
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

			await Task.Yield();
		}

		_ui.SetGameOverTextAlpha(1);
	}

	private float CalculateY(float x) => 4 * x * (1 - x);

	private async Task ShowPanel()
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

			await Task.Yield();
		}

		panel.localPosition = endPosition;
	}

	private async Task IncreaceCurrentScore()
	{
		int currentScore = _score.GetCurrentScore();

		_ui.SetCurrentScore(0);

		float t = 0;
		int score = 0;
		while (score < currentScore)
		{
			t += Time.deltaTime;
			score = CalculateScore(t);
			_ui.SetCurrentScore(score);

			await Task.Yield();
		}
	}

	private int CalculateScore(float x) => (int)(x * x);

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
