using System.Collections.Generic;
using Configs.Motion;
using MovingObjects;
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

		public List<T> Create<T>(Transform parent) where T : MonoBehaviour, IMovingObject
		{
			var obstacles = new List<T>(_config.ObjectsCount);

			for (int i = 0; i < _config.ObjectsCount; i++)
			{
				T obstacle = Object.Instantiate(_config.Prefab, parent).GetComponent<T>();
				obstacles.Add(obstacle);
			}

			return obstacles;
		}
	}
}
