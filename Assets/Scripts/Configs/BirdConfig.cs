using UnityEngine;

[CreateAssetMenu(menuName = "BirdConfig", order = 1)]
public class BirdConfig : ScriptableObject
{
	public Bird BirdPrefab { get => _birdPrefab; }

	public Vector3 StartPosition { get => _startPosition; }
	public float YOffset { get => _yOffset; }
	public float PreGameSpeed { get => _preGameSpeed; }

	public float FlapForce { get => _flapForce; }
	public Vector2 FlapOffset { get => _flapOffset; }

	public float MaxRotationAngle { get => _maxRotationAngle; }
	public float MinRotationAngle { get => _minRotationAngle; }

	public AudioClip CollisionedClip { get => _collisionedClip; }
	public AudioClip FlappedClip { get => _flappedClip; }
	public AudioClip PassedClip { get => _passedClip; }

	[Header("Presets")]
	[SerializeField] private Bird _birdPrefab;

	[SerializeField] private Vector3 _startPosition = new(-2.5f, 0f, 0f);

	[Header("Pre-game parameters")]
	[SerializeField] private float _yOffset = 0.3f;
	[SerializeField] private float _preGameSpeed = 5.5f;

	[Header("Parameters")]
	[SerializeField] private float _flapForce = 5.5f;
	[SerializeField] private Vector2 _flapOffset = new(-0.4f, 0.4f);

	[Header("Rotation")]
	[SerializeField] private float _maxRotationAngle = 45f;
	[SerializeField] private float _minRotationAngle = -45f;

	[Header("Audio")]
	[SerializeField] private AudioClip _collisionedClip;
	[SerializeField] private AudioClip _flappedClip;
	[SerializeField] private AudioClip _passedClip;
}
