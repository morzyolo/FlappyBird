using Configs.Horizontal;
using HeightDeterminers;
using MovingObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Resetters
{
	public class Resetter
	{
		public void Reset(
			List<IMovingObject> objects,
			HorizontalMotionConfig config,
			IHeightDeterminer heightDeterminer)
		{
			var spawnPosition = new Vector3(config.StartX, 0f, 0f);

			for (int i = 0; i < objects.Count; i++)
			{
				spawnPosition.y = heightDeterminer.Height;
				objects[i].SetPosition(spawnPosition);
				spawnPosition.x += config.XOffset;
			}
		}
	}
}
