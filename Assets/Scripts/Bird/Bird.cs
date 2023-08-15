using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public event Action PipePassed;
	public event Action Collisioned;

	[SerializeField] private BirdFlapping _birdFlapping;
	[SerializeField] private BirdAnimator _birdAnimator;
	[SerializeField] private BirdCrossingDetector _birdCrossingDetector;

	private BirdTurn _birdTurn;

	public void Initialize(BirdConfig config)
	{
		_birdTurn = new BirdTurn(transform, config);
		_birdFlapping.Initialize(_birdTurn, config);
		_birdAnimator.Initialize(_birdCrossingDetector);
	}

	public void Flap() => _birdFlapping.Flap();

	public void Reset()
	{
		transform.rotation = Quaternion.identity;
		_birdFlapping.ResetVelocity();
		_birdAnimator.Reset();
	}

	public void MakePhisical() => _birdFlapping.SetBodyType(RigidbodyType2D.Dynamic);

	public void MakeNonPhisical() => _birdFlapping.SetBodyType(RigidbodyType2D.Kinematic);

	private void NotifyPipePass() => PipePassed?.Invoke();

	private void NotifyCollision() => Collisioned?.Invoke();

	private void OnEnable()
	{
		_birdCrossingDetector.PipePassed += NotifyPipePass;
		_birdCrossingDetector.Collisioned += NotifyCollision;
	}

	private void OnDisable()
	{
		_birdCrossingDetector.PipePassed -= NotifyPipePass;
		_birdCrossingDetector.Collisioned -= NotifyCollision;
	}

}
