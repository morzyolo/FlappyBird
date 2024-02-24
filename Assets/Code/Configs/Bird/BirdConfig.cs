using Bird;
using Configs.Bird.Data;
using Configs.Motion;
using UnityEngine;

namespace Configs.Bird
{
	[CreateAssetMenu(menuName = "BirdConfig", order = 1)]
	public class BirdConfig : ScriptableObject
	{
		public BirdFacade BirdPrefab => _birdPrefab;

		public Vector3 StartPosition => _startPosition;

		public SinusMotionConfig SinusMotion => _sinusMotion;

		public float FlapForce => _flapForce;
		public Vector2 FlapOffset => _flapOffset;

		public float MaxRotationAngle => _maxRotationAngle;
		public float MinRotationAngle => _minRotationAngle;

		public AudioClip CollidedClip => _collisionedClip;
		public AudioClip FlappedClip => _flappedClip;
		public AudioClip PassedClip => _passedClip;

		public BirdAnimationData AnimationData => _animationData;

		[Header("Presets")]
		[SerializeField] private BirdFacade _birdPrefab;
		[SerializeField] private Vector3 _startPosition = new(-2.5f, 0f, 0f);

		[Header("Sinus Moving")]
		[SerializeField] private SinusMotionConfig _sinusMotion;

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
