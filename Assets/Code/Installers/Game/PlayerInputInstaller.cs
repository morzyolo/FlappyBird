using Input;
using Zenject;

namespace Installers.Game
{
	public class PlayerInputInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<PlayerInput>()
				.AsSingle()
				.NonLazy();
		}
	}
}
