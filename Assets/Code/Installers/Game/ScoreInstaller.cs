using Models;
using Zenject;

namespace Installers.Game
{
	public class ScoreInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container
				.BindInterfacesAndSelfTo<Score>()
				.AsSingle();
		}
	}
}
