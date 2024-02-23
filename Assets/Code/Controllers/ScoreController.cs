using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Models;
using UI.Views.Game;

namespace Controllers
{
	public sealed class ScoreController : IDisposable
	{
		private readonly ScoreView _view;
		private readonly Score _score;
		private readonly InGameState _state;

		public ScoreController(ScoreView view, Score score, StateMachine stateMachine)
		{
			_view = view;
			_score = score;
			_state = stateMachine.ResolveState<InGameState>();

			_view.Hide();
			_state.OnEntered += Enable;
			_state.OnExited += Disable;

			_score.OnValueChanged += ChangeScore;
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;

			_score.OnValueChanged += ChangeScore;
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