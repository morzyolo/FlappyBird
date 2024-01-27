using UnityEngine;

namespace SpriteChangers
{
	public class SpriteRendererChanger : ISpriteChanger
	{
		private readonly SpriteRenderer _spriteRenderer;

		public SpriteRendererChanger(SpriteRenderer spriteRenderer)
			=> _spriteRenderer = spriteRenderer;

		public void ChangeSprite(Sprite sprite)
			=> _spriteRenderer.sprite = sprite;
	}
}
