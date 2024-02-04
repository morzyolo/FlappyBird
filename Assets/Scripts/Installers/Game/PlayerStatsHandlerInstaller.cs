using DataHandlers.Handlers;
using Zenject;

namespace Installers.Game
{
	public class PlayerStatsHandlerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.Bind<PlayerStatsDataHandler>()
				.To<PlayerStatsDataHandler>()
				.AsSingle();
		}
	}
}
