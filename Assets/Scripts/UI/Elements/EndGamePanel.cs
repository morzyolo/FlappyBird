using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
	[RequireComponent(typeof(RectTransform))]
	public class EndGamePanel : MonoBehaviour
	{
		[SerializeField] private RectTransform _rect;

		[SerializeField] private Vector3 _hiddenPosition;
		[SerializeField] private Vector3 _shownPosition;
		[SerializeField] private float _showDuration = 1f;

		[SerializeField] private TMP_Text _currentScore;
		[SerializeField] private float _increaseDuration = 1f;

		[SerializeField] private TMP_Text _bestScore;
		[SerializeField] private RectTransform _newBestScoreLabel;

		public async UniTask Show(int currentScore, int bestScore)
		{
			gameObject.SetActive(true);

			_bestScore.text = bestScore.ToString();

			await _rect.DOAnchorPos(_shownPosition, _showDuration);

			await IncreaseToCurrentScore(currentScore);

			if (currentScore > bestScore)
				ShowNewBestScoreLabel(bestScore);
		}

		public void Hide()
		{
			_rect.anchoredPosition = _hiddenPosition;
			_bestScore.text = string.Empty;
			_currentScore.text = string.Empty;
			gameObject.SetActive(false);
		}

		private async UniTask IncreaseToCurrentScore(int currentScore)
		{
			int changeableScore = 0;
			await DOTween
				.To(() => changeableScore, value => changeableScore = value, currentScore, _increaseDuration)
				.OnUpdate(() => _currentScore.text = changeableScore.ToString())
				.SetEase(Ease.InOutSine).ToUniTask();
		}

		private void ShowNewBestScoreLabel(int bestScore)
		{
			_newBestScoreLabel.gameObject.SetActive(true);
			_bestScore.text = bestScore.ToString();
		}
	}
}
