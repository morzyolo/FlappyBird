using System;
using Transition;
using UI.Views.MainMenu;
using UnityEditor;
using Zenject;

namespace Presenters.MainMenu
{
	public sealed class MenuPresenter : IInitializable, IDisposable
	{
		private readonly MenuView _view;
		private readonly SceneChanger _sceneChanger;
		private readonly SceneAsset _gameScene;

		public MenuPresenter(
			MenuView view,
			SceneChanger sceneChanger,
			SceneAsset gameScene)
		{
			_view = view;
			_sceneChanger = sceneChanger;
			_gameScene = gameScene;

			_view.PlayButtonPressed += StartGame;
		}

		public async void Initialize()
		{
			await _sceneChanger.ShowScreen();
		}

		public async void StartGame()
		{
			await _sceneChanger.ChangeSceneAsync(_gameScene.name);
		}

		public void Dispose()
		{
			_view.PlayButtonPressed -= StartGame;
		}
	}
}
