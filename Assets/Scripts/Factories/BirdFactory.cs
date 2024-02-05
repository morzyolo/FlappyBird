using Bird;
using Bird.Components;
using Configs.Bird;
using UnityEngine;

namespace Factories
{
	public class BirdFactory
	{
		private readonly BirdConfig _config;

		public BirdFactory(BirdConfig config)
		{
			_config = config;
		}

		public BirdFacade Create()
		{
			var bird = Object.Instantiate(_config.BirdPrefab, _config.StartPosition, Quaternion.identity);
			bird.GetComponent<BirdInitializer>().Initialize();
			return bird;
		}
	}
}
