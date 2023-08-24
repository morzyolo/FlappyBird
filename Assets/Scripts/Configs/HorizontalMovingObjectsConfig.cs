using UnityEngine;

[CreateAssetMenu(menuName = "MovingObjectsConfig/Horizontal", order = 2)]
public class HorizontalMovingObjectsConfig : ScriptableObject
{
	public MovingObject Prefab { get => _prefab; }

	public int ObjectsCount { get => _objectsCount; }

	public float MoveSpeed { get => _moveSpeed; }

	public float StartX { get => _startX; }
	public float EndX { get => _endX; }
	public float XOffset { get => _xOffset; }

	public float MaxHeight { get => _maxHeight; }
	public float MinHeight { get => _minHeight;}

	[SerializeField] private MovingObject _prefab;

	[SerializeField] private int _objectsCount = 4;
	[SerializeField] private float _moveSpeed = 1f;

	[SerializeField] private float _startX = 8f;
	[SerializeField] private float _endX = -6f;
	[SerializeField] private float _xOffset = 1f;

	[SerializeField] private float _maxHeight = 0f;
	[SerializeField] private float _minHeight = 0f;
}