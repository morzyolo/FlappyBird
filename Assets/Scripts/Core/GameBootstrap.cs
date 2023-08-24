using System.Collections.Generic;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private FadeConfig _fadeConfig;
	[SerializeField] private BirdConfig _birdConfig;
	[SerializeField] private HorizontalMovingObjectsConfig _obstaclesConfig;
	[SerializeField] private HorizontalMovingObjectsConfig _groundsConfig;

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
	[SerializeField] private FadeImage _fadeImage;

	private Fading _fading;

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
		_birdPreGameMover = new BirdPreGameMover(bird, _notifier, _birdConfig, _updater);

		var gameIntroducer = new GameIntroducer(_preGameUI, _notifier);

		_fading = new Fading(_fadeConfig, _fadeImage);
		var sceneChanger = new SceneChanger(_fading);
		var gameRestarter = new GameRestarter(_fading);
		_gameResult = new GameResult(score, _endGameUI, gameRestarter, _notifier, sceneChanger);
		_notifier.Initialize(bird, gameIntroducer, gameRestarter);
	}

	private void Start()
	{
		_fading.Start();
	}

	private void InitializeObstaclesMover()
	{
		var obstacles = CreateMovingObjects(_obstaclesConfig, _obstaclesContainer);

		var obstaclesSetter = new ObstaclesDefaultSetter(obstacles, _obstaclesConfig, _notifier);
		_obstaclesMover = new ObstaclesMover(_notifier, obstacles, obstaclesSetter, _obstaclesConfig, _updater);
	}

	private void InitializeGroundsMover()
	{
		var grounds = CreateMovingObjects(_groundsConfig, _groundsContainer);

		var groundsSetter = new GroundsDefaultSetter(grounds, _groundsConfig, _notifier);
		_groundsMover = new GroundsMover(_notifier, grounds, groundsSetter, _groundsConfig, _updater);
	}

	private List<MovingObject> CreateMovingObjects(HorizontalMovingObjectsConfig config, Transform container)
		=> new MovingObjectsFactory(config).Create(container);
}
