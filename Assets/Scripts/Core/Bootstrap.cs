using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private PipesConfig _pipesConfig;

	[SerializeField] private Updater _updater;
	[SerializeField] private PlayerInput _playerInput;
	[SerializeField] private GameEventNotifier _gameEventNotifier;

	[SerializeField] private PipesMover _pipeMover;

	private void Awake()
	{
		var birdFactory = new BirdFactory(_birdConfig);
		var bird = birdFactory.Create();

		_gameEventNotifier.Initialize(bird);
		_playerInput.Initialize(bird, _updater, _gameEventNotifier);

		var pipeFacory = new PipesFactory(_pipesConfig);
		var pipes = pipeFacory.Create(_pipeMover.transform);

		_pipeMover.Initialize(pipes, _pipesConfig, _updater, _gameEventNotifier);
	}
}
