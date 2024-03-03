using Presenters.MainMenu;
using SceneReference;
using UI.Views.MainMenu;
using UnityEngine;
using Zenject;

namespace Installers.MainMenu
{
	public class MenuInstaller : MonoInstaller
	{
		[SerializeField] private MenuView _menuView;
		[SerializeField] private SceneRef _gameScene;

		public override void InstallBindings()
		{
			BindMenuView();
			BindMenuPresenter();
		}

		private void BindMenuView()
		{
			Container
				.BindInstance(_menuView)
				.AsSingle();
		}

		private void BindMenuPresenter()
		{
			Container
				.BindInterfacesTo<MenuPresenter>()
				.AsSingle()
				.WithArguments(_gameScene)
				.NonLazy();
		}
	}
}
