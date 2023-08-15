using System.Collections.Generic;
using UnityEngine;

public class ObstaclesFactory
{
	private readonly PipesConfig _pipesConfig;

	public ObstaclesFactory(PipesConfig config)
	{
		_pipesConfig = config;
	}

	public List<Obstacle> Create(Transform parent)
	{
		var obstacles = new List<Obstacle>(_pipesConfig.PipesCount);

		for (int i = 0; i < _pipesConfig.PipesCount; i++)
		{
			var obstacle = Object.Instantiate(_pipesConfig.PipeObstaclePrefab, parent);
			obstacles.Add(obstacle);
		}

		return obstacles;
	}
}
