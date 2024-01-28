using Configs.Horizontal;
using System.Collections.Generic;
using UnityEngine;

namespace Factories
{
	public class MovingObjectFactory
	{
		private readonly HorizontalMotionConfig _config;

		public MovingObjectFactory(HorizontalMotionConfig config)
		{
			_config = config;
		}

		public List<MovingObject> Create(Transform parent)
		{
			var obstacles = new List<MovingObject>(_config.ObjectsCount);

			for (int i = 0; i < _config.ObjectsCount; i++)
			{
				var obstacle = Object.Instantiate(_config.Prefab, parent).GetComponent<MovingObject>();
				obstacles.Add(obstacle);
			}

			return obstacles;
		}
	}
}
