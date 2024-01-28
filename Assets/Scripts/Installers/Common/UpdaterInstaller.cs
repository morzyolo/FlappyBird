using Core;
using Zenject;

namespace Installers.Common
{
	public class UpdaterInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindUpdater();
		}

		private void BindUpdater()
		{
			Container
				.BindInterfacesAndSelfTo<Updater>()
				.AsSingle();
		}
	}
}
