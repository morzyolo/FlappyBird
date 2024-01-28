using Extensions;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.MainMenu
{
	public class MenuView : MonoBehaviour
	{
		public event Action PlayButtonPressed;

		[SerializeField] private Button _startButton;

		private void NotifyPlay()
		{
			PlayButtonPressed?.Invoke();
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
