using Configs.Horizontal;
using HeightDeterminers;
using MovingObjects;
using System.Collections.Generic;

namespace Resetters
{
	public class GroundResetter
	{
		private readonly Resetter _resetter;
		private readonly List<IMovingObject> _grounds;
		private readonly HorizontalMotionConfig _config;
		private readonly IHeightDeterminer _heightDeterminer;

		public GroundResetter(
			Resetter resetter,
			List<IMovingObject> grounds,
			HorizontalMotionConfig config)
		{
			_grounds = grounds;
			_resetter = resetter;
			_config = config;
			_heightDeterminer = new ConstHeightDeterminer(_config.MaxHeight);
		}

		public void Reset()
			=> _resetter.Reset(_grounds, _config, _heightDeterminer);
	}
}
