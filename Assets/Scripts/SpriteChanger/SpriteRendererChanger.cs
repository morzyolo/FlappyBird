using UnityEngine;

public class SpriteRendererChanger : SpriteChanger
{
	private readonly SpriteRenderer _spriteRenderer;

	public SpriteRendererChanger(SpriteRenderer spriteRenderer)
		=> _spriteRenderer = spriteRenderer;

	public override void ChangeSprite(Sprite sprite)
		=> _spriteRenderer.sprite = sprite;
}
