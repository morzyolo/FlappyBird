using Presenters.Game;
using Zenject;

namespace Installers.Game
{
	public class PresenterInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindPresenter<StartGamePresenter>();
			BindPresenter<EndGamePresenter>();
		}

		private void BindPresenter<TPresenter>()
		{
			Container
				.BindInterfacesAndSelfTo<TPresenter>()
				.AsSingle()
				.NonLazy();
		}
	}
}
