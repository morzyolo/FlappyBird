using System;
using Bird.Components;
using UnityEngine;
using Zenject;

namespace Bird
{
	public sealed class BirdFacade : MonoBehaviour, IInitializable, IDisposable
	{
		public event Action ObstaclePassed
		{
			add => _crossingDetector.ObstaclePassed += value;
			remove => _crossingDetector.ObstaclePassed -= value;
		}

		public event Action Collided
		{
			add => _crossingDetector.Collided += value;
			remove => _crossingDetector.Collided -= value;
		}

		private BirdCrossingDetector _crossingDetector;

		private BirdFlapping _flapping;
		private BirdAnimator _animator;

		public void Construct(
			BirdAnimator animator,
			BirdFlapping birdFlapping,
			BirdCrossingDetector crossingDetector)
		{
			_animator = animator;
			_flapping = birdFlapping;
			_crossingDetector = crossingDetector;
		}

		public void Flap()
		{
			_flapping.Flap();
		}

		public void ResetStats()
		{
			transform.rotation = Quaternion.identity;
			_flapping.Reset();
			_animator.StartFlapping();
		}

		public void MakePhysical() => _flapping.SetBodyType(RigidbodyType2D.Dynamic);

		public void MakeNonPhysical() => _flapping.SetBodyType(RigidbodyType2D.Kinematic);

		public void Initialize()
		{
			Collided += StopAnimator;
		}

		public void Dispose()
		{
			Collided -= StopAnimator;

			_flapping.Dispose();
			_animator.Dispose();
		}

		private void StopAnimator()
		{
			_animator.StopFlapping();
		}
	}
}
