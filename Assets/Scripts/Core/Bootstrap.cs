using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private MovingObjectsConfig _obstaclesConfig;
	[SerializeField] private MovingObjectsConfig _groundsConfig;

	[Header("Core")]
	[SerializeField] private Updater _updater;
	[SerializeField] private GameEventNotifier _notifier;

	[Header("Environment")]
	[SerializeField] private Transform _groundsContainer;
	[SerializeField] private Transform _obstaclesContainer;

	[Header("Audio")]
	[SerializeField] private BirdAudioSource _birdAudioSource;

	[Header("UI")]
	[SerializeField] private PreGameUI _preGameUI;
	[SerializeField] private ScoreUI _scoreUI;
	[SerializeField] private EndGameUI _endGameUI;

	[Header("Transition")]
	[SerializeField] private Fading _fading;

	private GameResult _gameResult;

	private PlayerInput _playerInput;

	private GroundsMover _groundsMover;
	private ObstaclesMover _obstaclesMover;
	private BirdPreGameMover _birdPreGameMover;

	private void Awake()
	{
		InitializeGroundsMover();
		InitializeObstaclesMover();

		var birdFactory = new BirdFactory(_birdConfig);
		var bird = birdFactory.Create();

		var score = new Score(bird, _scoreUI, _notifier);

		_birdAudioSource.Initialize(bird, _birdConfig);
		_playerInput = new PlayerInput(bird, _updater, _notifier);
		_birdPreGameMover = new BirdPreGameMover(bird, _updater, _birdConfig, _notifier);

		var gameIntroducer = new GameIntroducer(_preGameUI, _notifier);

		var gameRestarter = new GameRestarter(_fading);
		_gameResult = new GameResult(score, _endGameUI, gameRestarter, _notifier);
		_notifier.Initialize(bird, gameIntroducer, gameRestarter);
	}

	private void InitializeObstaclesMover()
	{
		var obstacles = CreateMovingObjects(_obstaclesConfig, _obstaclesContainer);

		var obstaclesSetter = new ObstaclesDefaultSetter(obstacles, _obstaclesConfig, _notifier);
		_obstaclesMover = new ObstaclesMover(obstacles, obstaclesSetter, _notifier, _updater, _obstaclesConfig);
	}

	private void InitializeGroundsMover()
	{
		var grounds = CreateMovingObjects(_groundsConfig, _groundsContainer);

		var groundsSetter = new GroundsDefaultSetter(grounds, _groundsConfig, _notifier);
		_groundsMover = new GroundsMover(grounds, groundsSetter, _notifier, _updater, _groundsConfig);
	}

	private List<MovingObject> CreateMovingObjects(MovingObjectsConfig config, Transform container)
		=> new MovingObjectsFactory(config).Create(container);
}
