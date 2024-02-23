using TMPro;
using UnityEngine;

namespace UI.Views.Game
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;

		public void Show() => gameObject.SetActive(true);

		public void Hide() => gameObject.SetActive(false);

		public void SetScore(int score) => _text.text = score.ToString();
	}
}
