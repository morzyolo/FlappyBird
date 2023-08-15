using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;

	public void Show() => _text.gameObject.SetActive(true);

	public void Hide() => _text.gameObject.SetActive(false);

	public void SetScore(int score) => _text.text = score.ToString();
}
