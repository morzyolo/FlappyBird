using UnityEngine;
using UnityEngine.UI;

public class PreGameUI : MonoBehaviour
{
	[SerializeField] private Button _startButton;
	[SerializeField] private Image[] _images;

	private GameIntroducer _gameIntroducer;

	public void Initialize(GameIntroducer gameIntroducer)
	{
		_gameIntroducer = gameIntroducer;
	}

	public void Show()
	{
		SetActive(true);
		_startButton.AddListener(NotifyStartButtonPressed);
	}

	public void Hide()
	{
		_startButton.RemoveListener(NotifyStartButtonPressed);
		SetActive(false);
	}

	private void SetActive(bool isActive)
	{
		_startButton.SetActive(isActive);

		for (int i = 0; i < _images.Length; i++)
			_images[i].gameObject.SetActive(isActive);
	}

	private void NotifyStartButtonPressed() => _gameIntroducer.NotifyStartGame();

	private void OnDisable() => _startButton.RemoveListener(NotifyStartButtonPressed);
}
