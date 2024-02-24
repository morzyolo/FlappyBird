using Bird;
using Configs.Bird;
using Factories;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
	public class BirdFacadeInstaller : MonoInstaller
	{
		[SerializeField] private BirdConfig _config;

		public override void InstallBindings()
		{
			BirdFactory factory = new(_config);
			BirdFacade bird = factory.Create();

			Container
				.BindInterfacesAndSelfTo<BirdFacade>()
				.FromInstance(bird)
				.AsSingle();
		}
	}
}
