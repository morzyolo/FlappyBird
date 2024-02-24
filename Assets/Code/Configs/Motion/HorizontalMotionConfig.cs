using UnityEngine;

namespace Configs.Motion
{
	[CreateAssetMenu(menuName = "MotionConfig/Horizontal", order = 2)]
	public class HorizontalMotionConfig : ScriptableObject
	{
		public GameObject Prefab => _prefab;

		public int ObjectsCount => _objectsCount;

		public float MoveSpeed => _moveSpeed;

		public float StartX => _startX;
		public float EndX => _endX;
		public float XOffset => _xOffset;

		public float MaxHeight => _maxHeight;
		public float MinHeight => _minHeight;

		[SerializeField] private GameObject _prefab;

		[SerializeField] private int _objectsCount = 4;
		[SerializeField] private float _moveSpeed = 1f;

		[SerializeField] private float _startX = 8f;
		[SerializeField] private float _endX = -6f;
		[SerializeField] private float _xOffset = 1f;

		[SerializeField] private float _maxHeight = 0f;
		[SerializeField] private float _minHeight = 0f;
	}
}
