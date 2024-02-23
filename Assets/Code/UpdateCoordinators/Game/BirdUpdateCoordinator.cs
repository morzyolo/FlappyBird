using System;
using Bird;
using Configs.Bird;
using Core;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Cysharp.Threading.Tasks;
using ObjectMovers;
using UniRx;

namespace UpdateCoordinators.Game
{
	public sealed class BirdUpdateCoordinator : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

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
			_updateState.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_updateState.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
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
			_bird.Flap();
			_updater.RemoveListener(_mover);
		}
	}
}
