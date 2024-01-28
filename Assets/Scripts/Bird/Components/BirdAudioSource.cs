using Configs.Bird;
using System;
using UnityEngine;
using Zenject;

namespace Bird.Components
{
	public sealed class BirdAudioSource : IInitializable, IDisposable
	{
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
			_crossingDetector.Collided += PlayCollisionSound;
			_birdFlapping.Flapped += PlayFlapSound;
			_crossingDetector.ObstaclePassed += PlayPassClip;
		}

		public void Dispose()
		{
			_crossingDetector.Collided -= PlayCollisionSound;
			_birdFlapping.Flapped -= PlayFlapSound;
			_crossingDetector.ObstaclePassed -= PlayPassClip;
		}

		private void PlayCollisionSound() => PlayClip(_config.CollisionedClip);

		private void PlayFlapSound() => PlayClip(_config.FlappedClip);

		private void PlayPassClip() => PlayClip(_config.PassedClip);

		private void PlayClip(AudioClip clip)
		{
			_audioSource.clip = clip;
			_audioSource.Play();
		}
	}
}
