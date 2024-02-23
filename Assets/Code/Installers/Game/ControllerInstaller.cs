using Controllers;
using Zenject;

namespace Installers.Game
{
	public class ControllerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesTo<ScoreController>()
				.AsSingle()
				.NonLazy();
		}
	}
}
