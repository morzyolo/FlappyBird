using System.Collections.Generic;
using Configs.Motion;
using HeightDeterminers;
using MovingObjects;
using UnityEngine;

namespace ObjectMovers
{
	public class HorizontalMover<Object> : IObjectMover where Object : IMovingObject
	{
		private readonly IHeightDeterminer _heightDeterminer;
		private readonly List<Object> _objects;
		private readonly HorizontalMotionConfig _config;

		public HorizontalMover(
			IHeightDeterminer heightDeterminer,
			List<Object> objects,
			HorizontalMotionConfig config)
		{
			_heightDeterminer = heightDeterminer;
			_objects = objects;
			_config = config;
		}

		public void Tick(float deltaTime)
		{
			for (int i = 0; i < _objects.Count; i++)
			{
				_objects[i].Translate(_config.MoveSpeed * deltaTime * Vector3.left);

				if (_objects[i].XPosition < _config.EndX)
				{
					_objects[i].Translate(_objects.Count * _config.XOffset * Vector3.right);
					_objects[i].WithHeight(_heightDeterminer.Height);
				}
			}
		}
	}
}
