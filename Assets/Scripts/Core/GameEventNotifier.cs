using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventNotifier : MonoBehaviour
{
	public event Action GameStarted;
	public event Action GameOvered;
	public event Action GameRestarted;

	private Bird _bird;
	private GameIntroducer _introducer;
	private GameRestarter _restarter;

	private GameStage _currentStage = GameStage.InputStage;

	private readonly List<IDisposable> _disposableObjects = new();

	public void Initialize(Bird bird, GameIntroducer introducer, GameRestarter restarter)
	{
		_bird = bird;
		_introducer = introducer;
		_restarter = restarter;

		_introducer.GameStarted += NotifyStartGame;
		_bird.Collisioned += NotifyGameOver;
		_restarter.GameRestarted += NotifyRestartGame;
	}

	public void AddDisposable(IDisposable disposable) => _disposableObjects.Add(disposable);

	private void NotifyRestartGame()
	{
		if (_currentStage != GameStage.ResultStage)
			return;

		_currentStage = GameStage.InputStage;
		GameRestarted?.Invoke();
	}

	private void NotifyStartGame()
	{
		if (_currentStage != GameStage.InputStage)
			return;

		_currentStage = GameStage.InGameStage;
		GameStarted?.Invoke();
	}

	private void NotifyGameOver()
	{
		if (_currentStage != GameStage.InGameStage)
			return;

		_currentStage = GameStage.ResultStage;
		GameOvered?.Invoke();
	}

	private void OnDisable()
	{
		if (_bird != null)
			_bird.Collisioned -= NotifyGameOver;

		if (_introducer != null)
			_introducer.GameStarted -= NotifyStartGame;

		if (_restarter != null)
			_restarter.GameRestarted += NotifyRestartGame;

		foreach (var disposable in _disposableObjects)
			disposable.Dispose();
	}
}
