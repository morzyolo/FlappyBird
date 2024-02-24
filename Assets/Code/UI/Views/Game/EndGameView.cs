using Cysharp.Threading.Tasks;
using DG.Tweening;
using Extensions;
using TMPro;
using UI.Elements;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.Game
{
	public class EndGameView : MonoBehaviour
	{
		public ReactiveCommand OnRestartButtonPressed { get; } = new();
		public ReactiveCommand OnExitButtonPressed { get; } = new();

		[SerializeField] private EndGamePanel _panel;
		[SerializeField] private TMP_Text _gameOverText;
		[SerializeField] private float _showGameOverTextDuration;

		[Header("Buttons")]
		[SerializeField] private Button _restartButton;
		[SerializeField] private Button _exitButton;

		public async UniTaskVoid Show(int currentScore, int bestScore)
		{
			gameObject.SetActive(true);

			await ShowGameOverText();

			await _panel.Show(currentScore, bestScore);

			SetButtonsActive(true);
		}

		public void Hide()
		{
			_panel.Hide();

			Color gameOverColor = _gameOverText.color;
			gameOverColor.a = 0;
			_gameOverText.color = gameOverColor;

			SetButtonsActive(false);
			gameObject.SetActive(false);
		}

		private void SetButtonsActive(bool isActive)
		{
			_restartButton.gameObject.SetActive(isActive);
			_exitButton.gameObject.SetActive(isActive);
		}

		private async UniTask ShowGameOverText()
		{
			Color endColor = _gameOverText.color;
			endColor.a = 1;

			await _gameOverText
				.DOColor(endColor, _showGameOverTextDuration)
				.ToUniTask();
		}

		private void NotifyRestartButtonPressed() => OnRestartButtonPressed.Execute();

		private void NotifyExitButtonPressed() => OnExitButtonPressed.Execute();

		private void OnEnable()
		{
			_restartButton.AddListener(NotifyRestartButtonPressed);
			_exitButton.AddListener(NotifyExitButtonPressed);
		}

		private void OnDisable()
		{
			_restartButton.RemoveListener(NotifyRestartButtonPressed);
			_exitButton.RemoveListener(NotifyExitButtonPressed);
		}
	}
}
