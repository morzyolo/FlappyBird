using TMPro;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _currentScore;

	public void Show()
	{
		_currentScore.gameObject.SetActive(true);
	}

	public void Hide()
	{
		_currentScore.gameObject.SetActive(false);
	}

	public void SetCurrentScore(int score) => _currentScore.text = score.ToString();
}
