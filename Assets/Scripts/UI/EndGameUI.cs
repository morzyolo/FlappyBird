using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
	[SerializeField] private RectTransform _panel;

	[SerializeField] private TMP_Text _gameOverText;
	[SerializeField] private TMP_Text _currentScore;

	[SerializeField] private Button _restartButton;
	[SerializeField] private Button _exitButton;

	private GameResult _gameResult;

	public void Initialize(GameResult gameResult)
	{
		_gameResult = gameResult;
	}

	public void Hide()
	{
		_exitButton.onClick.RemoveListener(ChangeScene);
		_restartButton.onClick.RemoveListener(RestartGame);
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

	public void ShowButtons()
	{
		ButtonsSetActive(true);
		_exitButton.onClick.AddListener(ChangeScene);
		_restartButton.onClick.AddListener(RestartGame);
	}


	private void ButtonsSetActive(bool isActive)
	{
		_restartButton.gameObject.SetActive(isActive);
		_exitButton.gameObject.SetActive(isActive);
	}

	private void RestartGame() => _gameResult.RestartGame();

	private void ChangeScene() => _gameResult.ChangeScene();

	public void SetCurrentScore(int score) => _currentScore.text = score.ToString();

	private void OnDisable()
	{
		_exitButton.onClick.RemoveListener(ChangeScene);
		_restartButton.onClick.RemoveListener(RestartGame);
	}
}
