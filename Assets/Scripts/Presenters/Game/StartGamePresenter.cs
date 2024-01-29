using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using System;
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

		public void NotifyStartGame()
		{
			_state.GoToNext();
		}

		private void Enable()
		{
			_view.Show();
			_view.PlayButtonPressed += NotifyStartGame;
		}

		private void Disable()
		{
			_view.PlayButtonPressed -= NotifyStartGame;
			_view.Hide();
		}
	}
}
