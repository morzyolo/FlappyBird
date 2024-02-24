using System;
using UI.Views.Game;
using UniRx;
using Zenject;

namespace Core.StateMachines.Game.States
{
	public sealed class EndGameState : State, IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly EndGameView _endView;

		public EndGameState(EndGameView endView)
		{
			_endView = endView;
		}

		public void Initialize()
		{
			_endView.OnRestartButtonPressed
				.Subscribe(_ => GoToNext())
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<StartGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
