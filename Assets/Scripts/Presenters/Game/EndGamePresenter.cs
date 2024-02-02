using System;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Models;
using Transition;
using UI.Views.Game;
using UnityEditor;

namespace Presenters.Game
{
	public sealed class EndGamePresenter : IDisposable
	{
		private readonly EndGameView _view;
		private readonly Score _score;
		private readonly SceneAsset _menuScene;
		private readonly SceneChanger _sceneChanger;
		private readonly PlayerStatsDataHandler _statsHandler;

		private readonly State _state;

		public EndGamePresenter(
			EndGameView view,
			Score score,
			SceneAsset menuScene,
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
			_state.OnEntered += Enable;
			_state.OnExited += Disable;
			_view.OnExitButtonPressed += GoToMenu;
		}

		public void Dispose()
		{
			_state.OnEntered -= Enable;
			_state.OnExited -= Disable;
			_view.OnExitButtonPressed -= GoToMenu;
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

		private async void GoToMenu()
		{
			await _sceneChanger.ChangeSceneAsync(_menuScene.name);
		}
	}
}
