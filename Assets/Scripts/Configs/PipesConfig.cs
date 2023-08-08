using UnityEngine;

[CreateAssetMenu(menuName = "PipeConfig", order = 2)]
public class PipesConfig : ScriptableObject
{
	public Pipe PipePrefab { get => _pipePrefab; }

	public int PipesCount { get => _pipesCount; }

	public float PipeMoveSpeed { get => _pipeMoveSpeed; }

	public float StartX { get => _startX; }
	public float EndX { get => _endX; }
	public float XOffset { get => _xOffset; }

	public float MaxHeight { get => _maxHeight; }
	public float MinHeight { get => _minHeight;}

	[SerializeField] private Pipe _pipePrefab;

	[SerializeField] private int _pipesCount = 4;

	[SerializeField] private float _pipeMoveSpeed = 1f;

	[SerializeField] private float _startX = 8f;
	[SerializeField] private float _endX = -6f;
	[SerializeField] private float _xOffset = 3.5f;

	[SerializeField] private float _maxHeight = 4f;
	[SerializeField] private float _minHeight = -4f;
}