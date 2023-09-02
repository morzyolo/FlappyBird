using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : SpriteChanger
{
	private readonly Image _image;

	public ImageChanger(Image image)
		=> _image = image;

	public override void ChangeSprite(Sprite sprite)
		=> _image.sprite = sprite;
}
