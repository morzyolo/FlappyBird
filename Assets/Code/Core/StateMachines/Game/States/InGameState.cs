using System;
using Bird;
using Zenject;

namespace Core.StateMachines.Game.States
{
	public sealed class InGameState : State, IInitializable, IDisposable
	{
		private readonly BirdFacade _bird;

		public InGameState(BirdFacade bird)
		{
			_bird = bird;
		}

		public void Initialize()
		{
			_bird.Collided += GoToNext;
		}

		public void Dispose()
		{
			_bird.Collided -= GoToNext;
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<EndGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
