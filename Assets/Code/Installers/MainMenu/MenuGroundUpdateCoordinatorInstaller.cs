using System.Collections.Generic;
using Configs.Motion;
using Factories;
using MovingObjects;
using UnityEngine;
using UpdateCoordinators.Menu;
using Zenject;

namespace Installers.MainMenu
{
	public class MenuGroundUpdateCoordinatorInstaller : MonoInstaller
	{
		[SerializeField] private HorizontalMotionConfig _config;
		[SerializeField] private Transform _groundsRoot;

		public override void InstallBindings()
		{
			MovingObjectFactory factory = new(_config);
			var grounds = factory.Create<Ground>(_groundsRoot);

			BindGroundUpdateCoordinator(grounds);
		}

		private void BindGroundUpdateCoordinator(List<Ground> grounds)
		{
			Container
				.BindInterfacesTo<MenuGroundUpdateCoordinator>()
				.AsSingle()
				.WithArguments(grounds, _config)
				.NonLazy();
		}
	}
}