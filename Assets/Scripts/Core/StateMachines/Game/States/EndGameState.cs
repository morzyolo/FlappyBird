using System;
using UI.Views.Game;

namespace Core.StateMachines.Game.States
{
	public sealed class EndGameState : State, IDisposable
	{
		private readonly EndGameView _endView;

		public EndGameState(EndGameView endView)
		{
			_endView = endView;

			_endView.OnRestartButtonPressed += GoToNext;
		}

		public void Dispose()
		{
			_endView.OnRestartButtonPressed -= GoToNext;
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<StartGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
