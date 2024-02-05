using Presenters.Game;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
	public class PresenterInstaller : MonoInstaller
	{
		[SerializeField] private SceneAsset _menuScene;

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
