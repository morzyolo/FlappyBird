using Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainMenu
{
	public class MenuView : MonoBehaviour
	{
		public ReactiveCommand PlayButtonPressed { get; } = new();

		[SerializeField] private Button _startButton;

		private void NotifyPlay()
		{
			PlayButtonPressed.Execute();
		}

		private void OnEnable()
		{
			_startButton.AddListener(NotifyPlay);
		}

		private void OnDisable()
		{
			_startButton.RemoveListener(NotifyPlay);
		}
	}
}
