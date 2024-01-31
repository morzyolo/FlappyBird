using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using UI.Views.Game;

namespace Presenters.Game
{
	public sealed class StartGamePresenter : IDisposable
	{
		private readonly StartGameView _view;
		private readonly State _state;

		public StartGamePresenter(StartGameView view, StateMachine stateMachine)
		{
			_view = view;
			_state = stateMachine.ResolveState<StartGameState>();

			_view.Hide();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
		}

		private void Enable()
		{
			_view.Show();
		}

		private void Disable()
		{
			_view.Hide();
		}
	}
}
