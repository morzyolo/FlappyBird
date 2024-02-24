using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Cysharp.Threading.Tasks;
using DataHandlers.Handlers;
using Models;
using Transition;
using UI.Views.Game;
using UniRx;
using Utils.SceneReference;

namespace Presenters.Game
{
	public sealed class EndGamePresenter : IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly EndGameView _view;
		private readonly Score _score;
		private readonly SceneReference _menuScene;
		private readonly SceneChanger _sceneChanger;
		private readonly PlayerStatsDataHandler _statsHandler;

		private readonly State _state;

		public EndGamePresenter(
			EndGameView view,
			Score score,
			SceneReference menuScene,
			StateMachine stateMachine,
			SceneChanger sceneChanger,
			PlayerStatsDataHandler statsHandler
		)
		{
			_view = view;
			_score = score;
			_menuScene = menuScene;
			_sceneChanger = sceneChanger;
			_statsHandler = statsHandler;
			_state = stateMachine.ResolveState<EndGameState>();

			_view.Hide();
			_state.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_state.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);

			_view.OnExitButtonPressed
				.Subscribe(_ => GoToMenu().Forget())
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		private void Enable()
		{
			int maxScore = _statsHandler.Stats.MaxScore;

			if (_score.CurrentScore > maxScore)
			{
				PlayerStatsData newStatsData = _statsHandler.Stats;
				newStatsData.MaxScore = _score.CurrentScore;
				_statsHandler.SaveStats(newStatsData);
			}

			_view.Show(_score.CurrentScore, maxScore).Forget();
		}

		private void Disable()
		{
			_view.Hide();
		}

		private async UniTask GoToMenu()
		{
			await _sceneChanger.ChangeSceneAsync(_menuScene);
		}
	}
}
