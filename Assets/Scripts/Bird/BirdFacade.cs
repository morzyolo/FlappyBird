using Bird.Components;
using System;
using UnityEngine;
using Zenject;

namespace Bird
{
	public class BirdFacade : MonoBehaviour
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

		private BirdFlapping _flapping;
		private BirdAnimator _animator;
		private BirdCrossingDetector _crossingDetector;

		[Inject]
		public void Construct(
			BirdFlapping birdFlapping,
			BirdAnimator animator,
			BirdCrossingDetector crossingDetector)
		{
			_flapping = birdFlapping;
			_animator = animator;
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

		private void StopAnimator()
		{
			_animator.StopFlapping();
		}

		private void OnEnable()
		{
			Collided += StopAnimator;
		}

		private void OnDisable()
		{
			Collided -= StopAnimator;
		}
	}
}
