using System;
using System.Collections.Generic;
using Configs.Horizontal;
using Core;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using HeightDeterminers;
using MovingObjects.ObstacleComponents;
using ObjectMovers;
using Resetters;

namespace UpdateCoordinators.Game
{
	public sealed class ObstacleUpdateCoordinator : IDisposable
	{
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

			_resetState.OnEntered += Reset;
			_updateState.OnEntered += Enable;
			_updateState.OnExited += Disable;
		}

		public void Dispose()
		{
			_resetState.OnEntered -= Reset;
			_updateState.OnEntered -= Enable;
			_updateState.OnExited -= Disable;
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
