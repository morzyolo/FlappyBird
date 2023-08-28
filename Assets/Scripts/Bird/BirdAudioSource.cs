using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BirdAudioSource : MonoBehaviour
{
	private AudioSource _audioSource;

	private Bird _bird;

	private AudioClip _collisionedClip;
	private AudioClip _flappedClip;
	private AudioClip _passedClip;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void Initialize(Bird bird, BirdConfig config)
	{
		_bird = bird;

		_collisionedClip = config.CollisionedClip;
		_flappedClip = config.FlappedClip;
		_passedClip = config.PassedClip;

		_bird.Collisioned += PlayCollisionSound;
		_bird.Flapped += PlayFlapSound;
		_bird.ObstaclePassed += PlayPassClip;
	}

	private void PlayCollisionSound() => PlayClip(_collisionedClip);

	private void PlayFlapSound() => PlayClip(_flappedClip);

	private void PlayPassClip() => PlayClip(_passedClip);

	private void PlayClip(AudioClip clip)
	{
		_audioSource.clip = clip;
		_audioSource.Play();
	}

	private void OnDisable()
	{
		if (_bird != null)
		{
			_bird.Collisioned -= PlayCollisionSound;
			_bird.Flapped -= PlayFlapSound;
			_bird.ObstaclePassed -= PlayPassClip;
		}
	}
}
