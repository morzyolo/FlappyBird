using System;
using System.Collections.Generic;
using Configs.Motion;
using Core;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Cysharp.Threading.Tasks;
using HeightDeterminers;
using MovingObjects;
using ObjectMovers;
using Resetters;
using UniRx;

namespace UpdateCoordinators.Game
{
	public sealed class GroundUpdateCoordinator : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly Updater _updater;
		private readonly Resetter<Ground> _resetter;
		private readonly HorizontalMover<Ground> _mover;

		private readonly State _startState;
		private readonly State _endState;

		public GroundUpdateCoordinator(
			List<Ground> grounds,
			Updater updater,
			StateMachine stateMachine,
			HorizontalMotionConfig motionConfig)
		{
			_updater = updater;

			ConstHeightDeterminer heightDeterminer = new(motionConfig.MaxHeight);
			_resetter = new(grounds, motionConfig, heightDeterminer);
			_mover = new(heightDeterminer, grounds, motionConfig);

			_startState = stateMachine.ResolveState<StartGameState>();
			_endState = stateMachine.ResolveState<InGameState>();

			_startState.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_endState.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void Enable()
		{
			_resetter.Reset();
			_updater.AddListener(_mover);
		}

		private void Disable()
		{
			_updater.RemoveListener(_mover);
		}
	}
}
