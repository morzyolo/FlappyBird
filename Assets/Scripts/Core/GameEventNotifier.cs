using System;
using UnityEngine;

public class GameEventNotifier : MonoBehaviour
{
	public event Action GameStarted;
	public event Action GameOvered;
	public event Action GameQuited;
	public event Action GameRestarted;

	private Bird _bird;
	private GameIntroducer _introducer;
	private GameRestarter _restarter;

	private GameStage _currentStage = GameStage.InputStage;

	public void Initialize(Bird bird, GameIntroducer introducer, GameRestarter restarter)
	{
		_bird = bird;
		_introducer = introducer;
		_restarter = restarter;

		_introducer.GameStarted += NotifyStartGame;
		_bird.Collisioned += NotifyGameOver;
		_restarter.GameRestarted += NotifyRestartGame;
	}

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
		GameQuited?.Invoke();
		_introducer.GameStarted -= NotifyStartGame;
		_bird.Collisioned -= NotifyGameOver;
		_restarter.GameRestarted += NotifyRestartGame;
	}
}
