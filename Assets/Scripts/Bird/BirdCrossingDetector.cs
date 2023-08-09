using System;
using UnityEngine;

public class BirdCrossingDetector : MonoBehaviour
{
	public event Action PipePassed;
	public event Action Collisioned;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Pipe> (out var _))
			PipePassed?.Invoke();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Collisioned?.Invoke();
	}
}
