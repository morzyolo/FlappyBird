using Configs.Data;
using UnityEngine;

namespace Configs
{
	[CreateAssetMenu(menuName = "BirdConfig", order = 1)]
	public class BirdConfig : ScriptableObject
	{
		public Bird BirdPrefab { get => _birdPrefab; }

		public Vector3 StartPosition { get => _startPosition; }

		public SinusMovingObjectsConfig SinusMovingObjectsConfig { get => _sinusMovingConfig; }

		public float FlapForce { get => _flapForce; }
		public Vector2 FlapOffset { get => _flapOffset; }

		public float MaxRotationAngle { get => _maxRotationAngle; }
		public float MinRotationAngle { get => _minRotationAngle; }

		public AudioClip CollisionedClip { get => _collisionedClip; }
		public AudioClip FlappedClip { get => _flappedClip; }
		public AudioClip PassedClip { get => _passedClip; }

		public BirdAnimationData AnimationData => _animationData;

		[Header("Presets")]
		[SerializeField] private Bird _birdPrefab;
		[SerializeField] private Vector3 _startPosition = new(-2.5f, 0f, 0f);

		[Header("Sinus Moving")]
		[SerializeField] private SinusMovingObjectsConfig _sinusMovingConfig;

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

		[SerializeField] private BirdAnimationData _animationData;
	}
}
