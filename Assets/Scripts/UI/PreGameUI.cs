using UnityEngine;
using UnityEngine.UI;

public class PreGameUI : MonoBehaviour
{
	[SerializeField] private Button _startButton;

	private GameIntroducer _gameIntroducer;

	public void Initialize(GameIntroducer gameIntroducer)
	{
		_gameIntroducer = gameIntroducer;
	}

	public void Show()
	{
		_startButton.gameObject.SetActive(true);
		_startButton.onClick.AddListener(NotifyStartButtonPressed);
	}

	public void Hide()
	{
		_startButton.gameObject.SetActive(false);
		_startButton.onClick.RemoveListener(NotifyStartButtonPressed);
	}

	private void NotifyStartButtonPressed() => _gameIntroducer.NotifyStartGame();

	private void OnDisable() => _startButton.onClick.RemoveListener(NotifyStartButtonPressed);
}
