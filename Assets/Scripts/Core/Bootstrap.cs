using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private PipesConfig _pipesConfig;

	[Header("Core")]
	[SerializeField] private Updater _updater;
	[SerializeField] private GameEventNotifier _gameEventNotifier;

	[Header("Environment")]
	[SerializeField] private Transform _pipesObstacleContainer;

	[Header("UI")]
	[SerializeField] private PreGameUI _preGameUI;
	[SerializeField] private ScoreUI _scoreUI;
	[SerializeField] private EndGameUI _endGameUI;

	private PlayerInput _playerInput;
	private PipeObstaclesMover _pipeObstaclesMover;

	private Score _score;
	private BirdPreGameMover _birdPreGameMover;

	private GameIntroducer _gameIntroducer;
	private GameResult _gameResult; 

	private void Awake()
	{
		var obstaclesFactory = new PipeObstaclesFactory(_pipesConfig);
		var obstacles = obstaclesFactory.Create(_pipesObstacleContainer);

		_pipeObstaclesMover = new PipeObstaclesMover(obstacles, _pipesConfig, _updater, _gameEventNotifier);

		var birdFactory = new BirdFactory(_birdConfig);
		var bird = birdFactory.Create();

		_score = new Score(bird, _scoreUI, _gameEventNotifier);
		_playerInput = new PlayerInput(bird, _updater, _gameEventNotifier);
		_birdPreGameMover = new BirdPreGameMover(bird, _updater, _birdConfig, _gameEventNotifier);

		_gameIntroducer = new GameIntroducer(_preGameUI);
		_gameResult = new GameResult(_score, _endGameUI, _gameEventNotifier);
		_gameEventNotifier.Initialize(bird, _gameIntroducer);
	}
}
