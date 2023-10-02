using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
	[SerializeField] private RectTransform _panel;

	[SerializeField] private TMP_Text _gameOverText;
	[SerializeField] private TMP_Text _currentScore;
	[SerializeField] private TMP_Text _bestScore;
	[SerializeField] private RectTransform _newBestScore;

	[SerializeField] private Button _restartButton;
	[SerializeField] private Button _exitButton;

	private GameResult _gameResult;

	public void Initialize(GameResult gameResult)
	{
		_gameResult = gameResult;
	}

	public void Hide()
	{
		RemoveListenersFromButtons();
		_newBestScore.gameObject.SetActive(false);
		ButtonsSetActive(false);
	}

	public void SetGameOverTextAlpha(float alpha)
	{
		Color textColor = _gameOverText.color;
		textColor.a = alpha;
		_gameOverText.color = textColor;
	}

	public void SetPanelPosition(float yPosition)
	{
		Vector3 panelPosition = _panel.localPosition;
		panelPosition.y = yPosition;
		_panel.localPosition = panelPosition;
	}

	public RectTransform GetGameOverTextRectTransform() => _gameOverText.rectTransform;

	public RectTransform GetPanelRectTransform() => _panel;

	public void SetCurrentScore(int score) => _currentScore.text = score.ToString();

	public void SetBestScore(int bestScore) => _bestScore.text = bestScore.ToString();

	public void ShowButtons()
	{
		ButtonsSetActive(true);
		_exitButton.AddListener(ChangeScene);
		_restartButton.AddListener(RestartGame);
	}

	public void ShowNewBestScore() => _newBestScore.gameObject.SetActive(true);

	private void ButtonsSetActive(bool isActive)
	{
		_restartButton.SetActive(isActive);
		_exitButton.SetActive(isActive);
	}

	private void RestartGame() => _gameResult.RestartGame();

	private void ChangeScene() => _gameResult.ChangeScene();

	private void RemoveListenersFromButtons()
	{
		_exitButton.RemoveListener(ChangeScene);
		_restartButton.RemoveListener(RestartGame);
	}

	private void OnDisable()
	{
		RemoveListenersFromButtons();
	}
}
