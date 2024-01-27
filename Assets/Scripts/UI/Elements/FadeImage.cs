using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
	[RequireComponent(typeof(Image))]
	public class FadeImage : MonoBehaviour
	{
		private Image _image;

		private void Awake() => _image = GetComponent<Image>();

		public void SetAlpha(float alpha)
		{
			Color currentColor = _image.color;
			currentColor.a = alpha;
			_image.color = currentColor;
		}
	}
}
