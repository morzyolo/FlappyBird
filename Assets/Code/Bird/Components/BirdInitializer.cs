using Configs.Bird;
using SpriteChangers;
using UnityEngine;

namespace Bird.Components
{
	public class BirdInitializer : MonoBehaviour
	{
		[SerializeField] private BirdConfig _config;

		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private AudioSource _audioSource;

		[SerializeField] private BirdFacade _facade;
		[SerializeField] private BirdCrossingDetector _crossingDetector;

		private BirdAudioSource _birdAudio;

		public void Initialize()
		{
			BirdTurn turn = new(transform, _config);
			BirdFlapping flapping = new(transform, _rigidbody, _config, turn);

			SpriteRendererChanger spriteChanger = new(_spriteRenderer);
			BirdAnimator birdAnimator = new(spriteChanger, _config.AnimationData);

			_birdAudio = new(_crossingDetector, flapping, _audioSource, _config);
			_birdAudio.Initialize();
			_facade.Construct(birdAnimator, flapping, _crossingDetector);
		}

		private void OnDestroy()
		{
			_birdAudio.Dispose();
		}
	}
}
