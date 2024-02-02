using System;
using Bird;
using Configs.Bird;
using Core;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using ObjectMovers;

namespace UpdateCoordinators.Game
{
	public sealed class BirdUpdateCoordinator : IDisposable
	{
		private readonly BirdFacade _bird;
		private readonly Updater _updater;
		private readonly YSinusMover _mover;

		private readonly State _updateState;

		public BirdUpdateCoordinator(
			BirdFacade bird,
			Updater updater,
			BirdConfig config,
			StateMachine stateMachine)
		{
			_bird = bird;
			_updater = updater;
			_mover = new YSinusMover(bird.transform, config.SinusMotion);

			_updateState = stateMachine.ResolveState<StartGameState>();
			_updateState.OnEntered += Enable;
			_updateState.OnExited += Disable;
		}

		public void Dispose()
		{
			_updateState.OnEntered -= Enable;
			_updateState.OnExited -= Disable;
		}

		private void Enable()
		{
			_bird.ResetStats();
			_bird.MakeNonPhysical();
			_updater.AddListener(_mover);
		}

		private void Disable()
		{
			_bird.MakePhysical();
			_updater.RemoveListener(_mover);
		}
	}
}
