using System;
using Cysharp.Threading.Tasks;
using SceneReference;
using Transition;
using UI.Views.MainMenu;
using UniRx;
using Zenject;

namespace Presenters.MainMenu
{
	public sealed class MenuPresenter : IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly MenuView _view;
		private readonly SceneChanger _sceneChanger;
		private readonly SceneRef _gameScene;

		public MenuPresenter(
			MenuView view,
			SceneChanger sceneChanger,
			SceneRef gameScene)
		{
			_view = view;
			_sceneChanger = sceneChanger;
			_gameScene = gameScene;
		}

		public async void Initialize()
		{
			_view.PlayButtonPressed
				.Subscribe(_ => StartGame().Forget())
				.AddTo(_disposables);

			await _sceneChanger.ShowScreen();
		}

		public async UniTask StartGame()
		{
			await _sceneChanger.ChangeSceneAsync(_gameScene);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
