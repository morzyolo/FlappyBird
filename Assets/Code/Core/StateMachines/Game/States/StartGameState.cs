using System;
using UI.Views.Game;
using UniRx;
using Zenject;

namespace Core.StateMachines.Game.States
{
	public sealed class StartGameState : State, IInitializable, IDisposable
	{
		private readonly CompositeDisposable _dispodables = new();
		private readonly StartGameView _startView;

		public StartGameState(StartGameView startView)
		{
			_startView = startView;
		}

		public void Initialize()
		{
			_startView.PlayButtonPressed
				.Subscribe(_ => GoToNext())
				.AddTo(_dispodables);
		}

		public void Dispose()
		{
			_dispodables.Dispose();
		}

		private void GoToNext()
		{
			State nextState = StateMachine.ResolveState<InGameState>();
			StateMachine.ChangeState(this, nextState);
		}
	}
}
