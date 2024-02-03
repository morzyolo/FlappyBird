using Configs.Bird;
using UnityEngine;
using UpdateCoordinators.Game;
using Zenject;

namespace Installers.Game
{
	public class BirdUpdateCoordinatorInstaller : MonoInstaller
	{
		[SerializeField] private BirdConfig _config;

		public override void InstallBindings()
		{
			Container
				.BindInterfacesTo<BirdUpdateCoordinator>()
				.AsSingle()
				.WithArguments(_config)
				.NonLazy();
		}
	}
}
