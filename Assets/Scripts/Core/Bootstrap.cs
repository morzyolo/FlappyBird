using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private PipesConfig _pipesConfig;

	[Header("Core")]
	[SerializeField] private Updater _updater;
	[SerializeField] private PlayerInput _playerInput;
	[SerializeField] private GameEventNotifier _gameEventNotifier;

	[Header("Environment")]
	[SerializeField] private PipesMover _pipeMover;

	[Header("UI")]
	[SerializeField] private PreGameUI _preGameUI;
	[SerializeField] private ScoreUI _scoreUI;

	private Score _score;
	private BirdPreGameMover _birdPreGameMover;

	private void Awake()
	{
		var birdFactory = new BirdFactory(_birdConfig);
		var bird = birdFactory.Create();

		_gameEventNotifier.Initialize(_preGameUI, bird);
		_playerInput.Initialize(bird, _updater, _gameEventNotifier);
		_score = new Score(bird, _scoreUI, _gameEventNotifier);
		_birdPreGameMover = new BirdPreGameMover(bird, _updater, _birdConfig, _gameEventNotifier);

		var pipeFacory = new PipesFactory(_pipesConfig);
		var pipes = pipeFacory.Create(_pipeMover.transform);

		_pipeMover.Initialize(pipes, _pipesConfig, _updater, _gameEventNotifier);
	}
}
