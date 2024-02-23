using System;
using Bird;
using UniRx;
using Zenject;

namespace Core.StateMachines.Game.States
{
	public sealed class InGameState : State, IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly BirdFacade _bird;

		public InGameState(BirdFacade bird)
		{
			_bird = bird;
		}

		public void Initialize()
		{
			_bird.Collided
				.Subscribe(_ => GoToNext())
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<EndGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
