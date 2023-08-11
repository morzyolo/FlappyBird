using System.Collections.Generic;
using UnityEngine;

public class PipeObstaclesFactory
{
	private readonly PipesConfig _pipesConfig;

	public PipeObstaclesFactory(PipesConfig config)
	{
		_pipesConfig = config;
	}

	public List<PipeObstacle> Create(Transform parent)
	{
		var obstacles = new List<PipeObstacle>(_pipesConfig.PipesCount);
		var spawnPosition = new Vector3(_pipesConfig.StartX, 0f, 0f);

		for (int i = 0; i < _pipesConfig.PipesCount; i++)
		{
			float height = Random.Range(_pipesConfig.MinHeight, _pipesConfig.MaxHeight);

			var obstacle = Object.Instantiate(_pipesConfig.PipeObstaclePrefab,
				new Vector3(spawnPosition.x, height, 0f),
				Quaternion.identity,
				parent);
			obstacles.Add(obstacle);

			spawnPosition.x += _pipesConfig.XOffset;
		}

		return obstacles;
	}
}
