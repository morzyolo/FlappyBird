using System;
using System.Collections.Generic;
using Configs.Motion;
using Core;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Cysharp.Threading.Tasks;
using HeightDeterminers;
using MovingObjects.ObstacleComponents;
using ObjectMovers;
using Resetters;
using UniRx;

namespace UpdateCoordinators.Game
{
	public sealed class ObstacleUpdateCoordinator : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly Updater _updater;
		private readonly Resetter<Obstacle> _resetter;
		private readonly HorizontalMover<Obstacle> _mover;

		private readonly State _resetState;
		private readonly State _updateState;

		public ObstacleUpdateCoordinator(
			List<Obstacle> obstacles,
			Updater updater,
			StateMachine stateMachine,
			HorizontalMotionConfig motionConfig)
		{
			_updater = updater;

			RandomHeightDeterminer heightDeterminer = new(motionConfig.MinHeight, motionConfig.MaxHeight);
			_resetter = new(obstacles, motionConfig, heightDeterminer);
			_mover = new(heightDeterminer, obstacles, motionConfig);

			_resetState = stateMachine.ResolveState<StartGameState>();
			_updateState = stateMachine.ResolveState<InGameState>();

			_resetState.OnEntered.Subscribe(_ => Reset()).AddTo(_disposables);
			_updateState.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_updateState.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void Reset()
		{
			_resetter.Reset();
		}

		private void Enable()
		{
			_updater.AddListener(_mover);
		}

		private void Disable()
		{
			_updater.RemoveListener(_mover);
		}
	}
}
