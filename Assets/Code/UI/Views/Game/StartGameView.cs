using Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.Game
{
	public class StartGameView : MonoBehaviour
	{
		public ReactiveCommand PlayButtonPressed { get; } = new();

		[SerializeField] private Button _startButton;
		[SerializeField] private Image[] _images;

		public void Show() => SetActive(true);

		public void Hide() => SetActive(false);

		private void SetActive(bool isActive)
		{
			gameObject.SetActive(isActive);
			_startButton.SetActive(isActive);

			for (int i = 0; i < _images.Length; i++)
				_images[i].gameObject.SetActive(isActive);
		}

		private void NotifyPlayButtonPressed() => PlayButtonPressed.Execute();

		private void OnEnable()
		{
			_startButton.AddListener(NotifyPlayButtonPressed);
		}

		private void OnDisable()
		{
			_startButton.RemoveListener(NotifyPlayButtonPressed);
		}
	}
}
