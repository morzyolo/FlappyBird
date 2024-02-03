using System;
using UI.Views.Game;

namespace Core.StateMachines.Game.States
{
	public sealed class StartGameState : State, IDisposable
	{
		private readonly StartGameView _startView;

		public StartGameState(StartGameView startView)
		{
			_startView = startView;

			_startView.PlayButtonPressed += GoToNext;
		}

		public void Dispose()
		{
			_startView.PlayButtonPressed -= GoToNext;
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<InGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
