using UnityEngine;
using UnityEngine.UI;

namespace SpriteChangers
{
	public class ImageChanger : ISpriteChanger
	{
		private readonly Image _image;

		public ImageChanger(Image image)
			=> _image = image;

		public void ChangeSprite(Sprite sprite)
			=> _image.sprite = sprite;
	}
}
