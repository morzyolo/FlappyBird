using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private PipesConfig _pipesConfig;

	[Header("Core")]
	[SerializeField] private Updater _updater;
	[SerializeField] private GameEventNotifier _notifier;

	[Header("Environment")]
	[SerializeField] private Transform _obstaclesContainer;

	[Header("UI")]
	[SerializeField] private PreGameUI _preGameUI;
	[SerializeField] private ScoreUI _scoreUI;
	[SerializeField] private EndGameUI _endGameUI;

	private GameResult _gameResult;

	private PlayerInput _playerInput;

	private ObstaclesMover _obstaclesMover;
	private BirdPreGameMover _birdPreGameMover;

	private void Awake()
	{
		var obstaclesFactory = new ObstaclesFactory(_pipesConfig);
		var obstacles = obstaclesFactory.Create(_obstaclesContainer);

		var obstaclesSetter = new ObstaclesDefaultSetter(obstacles, _notifier, _pipesConfig);
		_obstaclesMover = new ObstaclesMover(obstacles, obstaclesSetter, _notifier, _updater, _pipesConfig);

		var birdFactory = new BirdFactory(_birdConfig);
		var bird = birdFactory.Create();

		var score = new Score(bird, _scoreUI, _notifier);

		_playerInput = new PlayerInput(bird, _updater, _notifier);
		_birdPreGameMover = new BirdPreGameMover(bird, _updater, _birdConfig, _notifier);

		var gameIntroducer = new GameIntroducer(_preGameUI, _notifier);

		var gameRestarter = new GameRestarter();
		_gameResult = new GameResult(score, _endGameUI, gameRestarter, _notifier);
		_notifier.Initialize(bird, gameIntroducer, gameRestarter);
	}
}
