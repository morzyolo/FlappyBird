using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _currentScore;

	[SerializeField] private Button _restartButton;

	private GameResult _gameResult;

	public void Initialize(GameResult gameResult)
	{
		_gameResult = gameResult;
	}

	public void Show()
	{
		_currentScore.gameObject.SetActive(true);
		_restartButton.gameObject.SetActive(true);
		_restartButton.onClick.AddListener(RestartGame);
	}

	public void Hide()
	{
		_currentScore.gameObject.SetActive(false);
		_restartButton.gameObject.SetActive(false);
		_restartButton.onClick.RemoveListener(RestartGame);
	}

	private void RestartGame() => _gameResult.RestartGame();

	public void SetCurrentScore(int score) => _currentScore.text = score.ToString();
}
