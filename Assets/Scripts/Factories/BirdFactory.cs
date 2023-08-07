using UnityEngine;

public class BirdFactory
{
	private readonly Bird _birdPrefab;
	private readonly BirdConfig _config;

	public BirdFactory(Bird birdPrefab, BirdConfig config)
	{
		_birdPrefab = birdPrefab;
		_config = config;
	}

	public Bird Create()
	{
		var bird = Object.Instantiate(_birdPrefab, _config.StartPosition, Quaternion.identity);
		bird.Initialize(_config);
		return bird;
	}
}
