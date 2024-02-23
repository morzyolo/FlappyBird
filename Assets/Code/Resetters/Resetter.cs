using System.Collections.Generic;
using Configs.Motion;
using HeightDeterminers;
using MovingObjects;
using UnityEngine;

namespace Resetters
{
	public class Resetter<Object> where Object : IMovingObject
	{
		private readonly List<Object> _objects;
		private readonly HorizontalMotionConfig _config;
		private readonly IHeightDeterminer _heightDeterminer;

		public Resetter(
			List<Object> objects,
			HorizontalMotionConfig config,
			IHeightDeterminer heightDeterminer)
		{
			_config = config;
			_objects = objects;
			_heightDeterminer = heightDeterminer;
		}

		public void Reset()
		{
			var spawnPosition = new Vector3(_config.StartX, 0f, 0f);

			for (int i = 0; i < _objects.Count; i++)
			{
				spawnPosition.y = _heightDeterminer.Height;
				_objects[i].SetPosition(spawnPosition);
				spawnPosition.x += _config.XOffset;
			}
		}
	}
}
