using System;
using UnityEngine;

public class BirdCrossingDetector : MonoBehaviour
{
	public event Action Collisioned;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Collisioned?.Invoke();
	}
}
