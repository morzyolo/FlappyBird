using System;
using Cysharp.Threading.Tasks;
using Transition;
using UI.Views.MainMenu;
using UniRx;
using Utils.SceneReference;
using Zenject;

namespace Presenters.MainMenu
{
	public sealed class MenuPresenter : IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly MenuView _view;
		private readonly SceneChanger _sceneChanger;
		private readonly SceneReference _gameScene;

		public MenuPresenter(
			MenuView view,
			SceneChanger sceneChanger,
			SceneReference gameScene)
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
