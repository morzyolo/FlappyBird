using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public event Action PipePassed;
	public event Action Collisioned;

	[SerializeField] private BirdFlapping _birdFlapping;
	[SerializeField] private BirdCrossingDetector _birdCrossingDetector;

	private BirdTurn _birdTurn;

	public void Initialize(BirdConfig config)
	{
		_birdTurn = new BirdTurn(transform, config);
		_birdFlapping.Initialize(_birdTurn, config);
	}

	public void Flap() => _birdFlapping.Flap();

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
