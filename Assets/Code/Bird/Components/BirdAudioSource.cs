using System;
using Configs.Bird;
using UniRx;
using UnityEngine;
using Zenject;

namespace Bird.Components
{
	public sealed class BirdAudioSource : IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly BirdCrossingDetector _crossingDetector;
		private readonly BirdFlapping _birdFlapping;
		private readonly AudioSource _audioSource;
		private readonly BirdConfig _config;

		public BirdAudioSource(
			BirdCrossingDetector crossingDetector,
			BirdFlapping birdFlapping,
			AudioSource audioSource,
			BirdConfig config)
		{
			_crossingDetector = crossingDetector;
			_birdFlapping = birdFlapping;
			_audioSource = audioSource;
			_config = config;
		}

		public void Initialize()
		{
			_crossingDetector.Collided
				.Subscribe(_ => PlayCollisionSound())
				.AddTo(_disposables);

			_birdFlapping.Flapped
				.Subscribe(_ => PlayFlapSound())
				.AddTo(_disposables);

			_crossingDetector.ObstaclePassed
				.Subscribe(_ => PlayPassClip())
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void PlayCollisionSound() => PlayClip(_config.CollidedClip);

		private void PlayFlapSound() => PlayClip(_config.FlappedClip);

		private void PlayPassClip() => PlayClip(_config.PassedClip);

		private void PlayClip(AudioClip clip)
		{
			_audioSource.clip = clip;
			_audioSource.Play();
		}
	}
}
