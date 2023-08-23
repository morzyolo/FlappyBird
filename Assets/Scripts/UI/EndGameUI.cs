using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
	[SerializeField] private RectTransform _panel;

	[SerializeField] private TMP_Text _currentScore;

	[SerializeField] private Button _restartButton;
	[SerializeField] private Button _exitButton;

	private GameResult _gameResult;

	public void Initialize(GameResult gameResult)
	{
		_gameResult = gameResult;
	}

	public void Show()
	{
		SetActive(true);
		_exitButton.onClick.AddListener(ChangeScene);
		_restartButton.onClick.AddListener(RestartGame);
	}

	public void Hide()
	{
		_exitButton.onClick.RemoveListener(ChangeScene);
		_restartButton.onClick.RemoveListener(RestartGame);
		SetActive(false);
	}

	private void SetActive(bool isActive)
	{
		_panel.gameObject.SetActive(isActive);
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
