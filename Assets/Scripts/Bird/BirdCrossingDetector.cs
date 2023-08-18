using System;
using UnityEngine;

public class BirdCrossingDetector : MonoBehaviour
{
	public event Action ObstaclePassed;
	public event Action Collisioned;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<PassTrigger> (out var _))
			ObstaclePassed?.Invoke();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Pipe>(out var pipe))
			pipe.transform.parent.GetComponent<Obstacle>().Deactivate();

		Collisioned?.Invoke();
	}
}
