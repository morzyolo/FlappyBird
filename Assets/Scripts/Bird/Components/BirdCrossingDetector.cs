using MovingObjects;
using MovingObjects.ObstacleComponents;
using System;
using UnityEngine;

namespace Bird.Components
{
	public class BirdCrossingDetector : MonoBehaviour
	{
		public event Action ObstaclePassed;
		public event Action Collided;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent<PassTrigger>(out var _))
				ObstaclePassed?.Invoke();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.TryGetComponent<ICanKill>(out var _))
			{
				if (collision.transform.TryGetComponent<IReactOnCollision>(out var component))
					component.OnCollision();

				Collided?.Invoke();
			}
		}
	}
}
