using System.Collections.Generic;
using UnityEngine;

public class PipesFactory
{
	private readonly PipesConfig _pipesConfig;

	public PipesFactory(PipesConfig config)
	{
		_pipesConfig = config;
	}

	public List<Pipe> Create(Transform parent)
	{
		var pipes = new List<Pipe>(_pipesConfig.PipesCount);
		var spawnPosition = new Vector3(_pipesConfig.StartX, 0f, 0f);

		for (int i = 0; i < _pipesConfig.PipesCount; i++)
		{
			float height = Random.Range(_pipesConfig.MinHeight, _pipesConfig.MaxHeight);

			var pipe = Object.Instantiate(_pipesConfig.PipePrefab,
				new Vector3(spawnPosition.x, height, 0f),
				Quaternion.identity,
				parent);

			spawnPosition.x += _pipesConfig.XOffset;

			pipes.Add(pipe);
		}

		return pipes;
	}
}
