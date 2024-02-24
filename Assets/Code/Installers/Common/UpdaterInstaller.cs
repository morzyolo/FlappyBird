using Core;
using Zenject;

namespace Installers.Common
{
	public class UpdaterInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<Updater>()
				.AsSingle();
		}
	}
}
