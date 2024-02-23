using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Models;
using UI.Views.Game;
using UniRx;

namespace Controllers
{
	public sealed class ScoreController : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly ScoreView _view;
		private readonly Score _score;
		private readonly InGameState _state;

		public ScoreController(ScoreView view, Score score, StateMachine stateMachine)
		{
			_view = view;
			_score = score;
			_state = stateMachine.ResolveState<InGameState>();

			_view.Hide();

			_state.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_state.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
			_score.Value.Subscribe(value => ChangeScore(value)).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void Enable()
		{
			_view.Show();
			_score.Reset();
			ChangeScore(_score.CurrentScore);
		}

		private void Disable()
		{
			_view.Hide();
		}

		private void ChangeScore(int score)
		{
			_view.SetScore(score);
		}
	}
}
