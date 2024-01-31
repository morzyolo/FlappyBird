using System;
using Bird;

namespace Core.StateMachines.Game.States
{
	public sealed class InGameState : State, IDisposable
	{
		private readonly BirdFacade _bird;

		public InGameState(BirdFacade bird)
		{
			_bird = bird;

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
