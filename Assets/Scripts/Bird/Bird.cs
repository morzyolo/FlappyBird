using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public event Action Flapped;

	public event Action ObstaclePassed;
	public event Action Collisioned;

	[SerializeField] private BirdFlapping _birdFlapping;
	[SerializeField] private BirdAnimator _birdAnimator;
	[SerializeField] private BirdCrossingDetector _birdCrossingDetector;

	[SerializeField] private SpriteRenderer _spriteRenderer;

	public void Initialize(BirdConfig config)
	{
		var birdTurn = new BirdTurn(transform, config);
		_birdFlapping.Initialize(birdTurn, config);
		var spriteChanger = new SpriteRendererChanger(_spriteRenderer);
		_birdAnimator = new BirdAnimator(spriteChanger, config);
	}

	private void Start() => _birdAnimator.StartFlapping();

	public void Flap()
	{
		Flapped?.Invoke();
		_birdFlapping.Flap();
	}

	public void Reset()
	{
		transform.rotation = Quaternion.identity;
		_birdFlapping.Reset();
		_birdAnimator.StartFlapping();
	}

	public void MakePhisical() => _birdFlapping.SetBodyType(RigidbodyType2D.Dynamic);

	public void MakeNonPhisical() => _birdFlapping.SetBodyType(RigidbodyType2D.Kinematic);

	private void NotifyPipePass() => ObstaclePassed?.Invoke();

	private void NotifyCollision()
	{
		_birdAnimator.StopFlapping();
		Collisioned?.Invoke();
	}

	private void OnEnable()
	{
		_birdCrossingDetector.ObstaclePassed += NotifyPipePass;
		_birdCrossingDetector.Collisioned += NotifyCollision;
	}

	private void OnDisable()
	{
		_birdCrossingDetector.ObstaclePassed -= NotifyPipePass;
		_birdCrossingDetector.Collisioned -= NotifyCollision;
		_birdAnimator?.Dispose();
	}
}
