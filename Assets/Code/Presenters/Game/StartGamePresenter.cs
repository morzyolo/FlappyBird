using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Cysharp.Threading.Tasks;
using Transition;
using UI.Views.Game;
using UniRx;

namespace Presenters.Game
{
	public sealed class StartGamePresenter : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly StartGameView _view;
		private readonly SceneChanger _sceneChanger;
		private readonly State _state;

		public StartGamePresenter(
			StartGameView view,
			SceneChanger sceneChanger,
			StateMachine stateMachine)
		{
			_view = view;
			_sceneChanger = sceneChanger;
			_state = stateMachine.ResolveState<StartGameState>();

			_view.Hide();
			_state.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_state.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void Enable()
		{
			_view.Show();
			_sceneChanger.ShowScreen().Forget();
		}

		private void Disable()
		{
			_view.Hide();
		}
	}
}
