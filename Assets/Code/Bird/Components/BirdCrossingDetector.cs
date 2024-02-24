using MovingObjects;
using MovingObjects.ObstacleComponents;
using UniRx;
using UnityEngine;

namespace Bird.Components
{
	public class BirdCrossingDetector : MonoBehaviour
	{
		public ReactiveCommand ObstaclePassed { get; } = new();
		public ReactiveCommand Collided { get; } = new();

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.TryGetComponent<PassTrigger>(out var _))
				ObstaclePassed.Execute();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.TryGetComponent<ICanKill>(out var _))
			{
				if (collision.transform.TryGetComponent<IReactOnCollision>(out var component))
					component.OnCollision();

				Collided.Execute();
			}
		}
	}
}
