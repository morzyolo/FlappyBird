using System;
using UI.Views.Game;
using Zenject;

namespace Core.StateMachines.Game.States
{
	public sealed class EndGameState : State, IInitializable, IDisposable
	{
		private readonly EndGameView _endView;

		public EndGameState(EndGameView endView)
		{
			_endView = endView;
		}

		public void Initialize()
		{
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
