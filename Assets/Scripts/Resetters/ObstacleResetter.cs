using Configs.Horizontal;
using HeightDeterminers;
using MovingObjects;
using System.Collections.Generic;

namespace Resetters
{
	public class ObstacleResetter
	{
		private readonly Resetter _resetter;
		private readonly List<IMovingObject> _obstacles;
		private readonly HorizontalMotionConfig _config;
		private readonly IHeightDeterminer _heightDeterminer;

		public ObstacleResetter(
			Resetter resetter,
			List<IMovingObject> obstacles,
			HorizontalMotionConfig config)
		{
			_resetter = resetter;
			_obstacles = obstacles;
			_config = config;
			_heightDeterminer = new RandomHeightDeterminer(_config.MinHeight, _config.MaxHeight);
		}

		public void Reset()
			=> _resetter.Reset(_obstacles, _config, _heightDeterminer);
	}
}
