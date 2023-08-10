using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	public void ShowScore() => _text.gameObject.SetActive(true);

	public void HideScore() => _text.gameObject.SetActive(false);

	public void SetScore(int score) => _text.text = score.ToString();
}
