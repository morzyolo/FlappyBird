using UnityEngine;

public class BirdFactory
{
	private readonly BirdConfig _config;

	public BirdFactory(BirdConfig config)
	{
		_config = config;
	}

	public Bird Create()
	{
		var bird = Object.Instantiate(_config.BirdPrefab, _config.StartPosition, Quaternion.identity);
		bird.Initialize(_config);
		return bird;
	}
}
