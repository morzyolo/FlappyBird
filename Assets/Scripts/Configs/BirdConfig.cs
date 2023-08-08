using UnityEngine;

[CreateAssetMenu(menuName = "BirdConfig", order = 1)]
public class BirdConfig : ScriptableObject
{
	public Bird BirdPrefab { get => _birdPrefab; }

	public Vector3 StartPosition { get => _startPosition; }

	public float FlapForce { get => _flapForce; }
	public Vector2 FlapOffset { get => _flapOffset; }

	public float MaxRotationAngle { get => _maxRotationAngle; }
	public float MinRotationAngle { get => _minRotationAngle; }

	[SerializeField] private Bird _birdPrefab;

	[SerializeField] private Vector3 _startPosition = new(-2.5f, 0f, 0f);

	[SerializeField] private float _flapForce = 2f;
	[SerializeField] private Vector2 _flapOffset = new(-0.2f, 0.1f);

	[SerializeField] private float _maxRotationAngle = 45f;
	[SerializeField] private float _minRotationAngle = -45f;
}