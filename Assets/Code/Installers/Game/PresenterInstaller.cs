using Presenters.Game;
using UnityEngine;
using Utils.SceneReference;
using Zenject;

namespace Installers.Game
{
	public class PresenterInstaller : MonoInstaller
	{
		[SerializeField] private SceneReference _menuScene;

		public override void InstallBindings()
		{
			BindStartGamePresenter();
			BindEndGamePresenter();
		}

		private void BindStartGamePresenter()
		{
			Container
				.BindInterfacesAndSelfTo<StartGamePresenter>()
				.AsSingle()
				.NonLazy();
		}

		private void BindEndGamePresenter()
		{
			Container
				.BindInterfacesAndSelfTo<EndGamePresenter>()
				.AsSingle()
				.WithArguments(_menuScene)
				.NonLazy();
		}
	}
}
