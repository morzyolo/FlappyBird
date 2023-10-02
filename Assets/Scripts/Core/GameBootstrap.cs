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
	[SerializeField] private AudioSource _audioSource;

	[Header("UI")]
	[SerializeField] private PreGameUI _preGameUI;
	[SerializeField] private ScoreUI _scoreUI;
	[SerializeField] private EndGameUI _endGameUI;
	[SerializeField] private FadeImage _fadeImage;
	[SerializeField] private InputPanel _inputPanel;

	private Fading _fading;

	private void Awake()
	{
		InitializeGroundsMover();
		InitializeObstaclesMover();

		var bird = new BirdFactory(_birdConfig).Create();

		var score = new Score(bird, _scoreUI, _notifier);

		_ = new BirdAudioSource(bird, _audioSource, _notifier, _birdConfig);
		_ = new PlayerInput(bird, _inputPanel, _notifier);
		_ = new BirdPreGameMover(bird, _notifier, _birdConfig, _updater);

		var gameIntroducer = new GameIntroducer(_preGameUI, _notifier);

		_fading = new Fading(_fadeConfig, _fadeImage);
		var sceneChanger = new SceneChanger(_fading);
		var gameRestarter = new GameRestarter(_fading);

		var statsDataHandler = new PlayerStatsDataHandler();

		_ = new GameResult(score, _endGameUI, gameRestarter, sceneChanger, _notifier, statsDataHandler);
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
		_ = new ObstaclesMover(_notifier, obstacles, obstaclesSetter, _obstaclesConfig, _updater);
	}

	private void InitializeGroundsMover()
	{
		var grounds = CreateMovingObjects(_groundsConfig, _groundsContainer);

		var groundsSetter = new GroundsDefaultSetter(grounds, _groundsConfig, _notifier);
		_ = new GroundsMover(grounds, groundsSetter, _groundsConfig, _updater, _notifier);
	}

	private List<MovingObject> CreateMovingObjects(HorizontalMovingObjectsConfig config, Transform container)
		=> new MovingObjectsFactory(config).Create(container);
}
