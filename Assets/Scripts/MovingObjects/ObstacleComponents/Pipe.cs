using UnityEngine;

namespace MovingObjects.ObstacleComponents
{
	[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
	public class Pipe : MonoBehaviour, ICanKill, IReactOnCollision
	{
		private Collider2D _collider;
		private SpriteRenderer _spriteRenderer;

		private bool _isPositive;
		private float _defaultXSize;
		private float _yOffsetFromZeroToSprite;

		private void Awake()
		{
			_collider = GetComponent<Collider2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();

			_isPositive = transform.localPosition.y > 0;
			_defaultXSize = _spriteRenderer.size.x;
			_yOffsetFromZeroToSprite = Mathf.Abs(transform.localPosition.y) - _spriteRenderer.size.y / 2;
			_yOffsetFromZeroToSprite *= _isPositive ? 1 : -1;
		}

		public void OnCollision()
		{
			SetActive(false);
		}

		public void SetActive(bool isActive)
		{
			_collider.enabled = isActive;
		}

		public void UpdateSize(in (float minBorder, float maxBorders) borders, float currentHeight)
			=> PutInBorders(_isPositive ? borders.maxBorders : borders.minBorder, currentHeight);

		private void PutInBorders(float border, float currentHeight)
		{
			float spriteYSize = border - currentHeight - _yOffsetFromZeroToSprite;
			_spriteRenderer.size = new Vector2(_defaultXSize, Mathf.Abs(spriteYSize));

			Vector3 newPosition = transform.position;
			newPosition.y = spriteYSize / 2 + _yOffsetFromZeroToSprite + currentHeight;
			transform.position = newPosition;
		}
	}
}
