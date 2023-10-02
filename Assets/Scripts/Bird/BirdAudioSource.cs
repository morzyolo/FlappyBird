using System;
using UnityEngine;

public class BirdAudioSource : IDisposable
{
	private readonly Bird _bird;
	private readonly AudioSource _audioSource;

	private readonly AudioClip _collisionedClip;
	private readonly AudioClip _flappedClip;
	private readonly AudioClip _passedClip;

	public BirdAudioSource(Bird bird, AudioSource audioSource, GameEventNotifier notifier, BirdConfig config)
	{
		_bird = bird;
		_audioSource = audioSource;

		_collisionedClip = config.CollisionedClip;
		_flappedClip = config.FlappedClip;
		_passedClip = config.PassedClip;

		_bird.Collisioned += PlayCollisionSound;
		_bird.Flapped += PlayFlapSound;
		_bird.ObstaclePassed += PlayPassClip;
		notifier.AddDisposable(this);
	}

	public void Dispose()
	{
		_bird.Collisioned -= PlayCollisionSound;
		_bird.Flapped -= PlayFlapSound;
		_bird.ObstaclePassed -= PlayPassClip;
	}

	private void PlayCollisionSound() => PlayClip(_collisionedClip);

	private void PlayFlapSound() => PlayClip(_flappedClip);

	private void PlayPassClip() => PlayClip(_passedClip);

	private void PlayClip(AudioClip clip)
	{
		_audioSource.clip = clip;
		_audioSource.Play();
	}
}
