using System.Collections.Generic;
using Configs.Motion;
using Factories;
using MovingObjects.ObstacleComponents;
using UnityEngine;
using UpdateCoordinators.Game;
using Zenject;

namespace Installers.Game
{
	public class ObstacleUpdateCoordinatorInstaller : MonoInstaller
	{
		[SerializeField] private HorizontalMotionConfig _config;
		[SerializeField] private Transform _obstaclesRoot;

		public override void InstallBindings()
		{
			MovingObjectFactory factory = new(_config);
			var obstacles = factory.Create<Obstacle>(_obstaclesRoot);

			BindObstacleUpdateCoordinator(obstacles);
		}

		private void BindObstacleUpdateCoordinator(List<Obstacle> obstacles)
		{
			Container
				.BindInterfacesTo<ObstacleUpdateCoordinator>()
				.AsSingle()
				.WithArguments(obstacles, _config)
				.NonLazy();
		}
	}
}
