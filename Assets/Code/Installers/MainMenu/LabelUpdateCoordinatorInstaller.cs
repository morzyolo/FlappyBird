using Configs.Motion;
using UnityEngine;
using UpdateCoordinators.Menu;
using Zenject;

namespace Installers.MainMenu
{
	public class LabelUpdateCoordinatorInstaller : MonoInstaller
	{
		[SerializeField] private Transform _labelRoot;
		[SerializeField] private SinusMotionConfig _motionConfig;

		public override void InstallBindings()
		{
			BindLabelUpdateCoordinator();
		}

		private void BindLabelUpdateCoordinator()
		{
			Container
				.BindInterfacesTo<LabelUpdateCoordinator>()
				.AsSingle()
				.WithArguments(_labelRoot, _motionConfig)
				.NonLazy();
		}
	}
}
