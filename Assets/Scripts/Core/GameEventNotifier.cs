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

	public void Initialize(Bird bird, GameIntroducer introducer, GameRestarter restarter)
	{
		_bird = bird;
		_introducer = introducer;
		_restarter = restarter;

		_introducer.GameStarted += NotifyStartGame;
		_bird.Collisioned += NotifyGameOver;
		_restarter.GameRestarted += NotifyRestartGame;
	}

	private void NotifyRestartGame() => GameRestarted?.Invoke();

	private void NotifyStartGame() => GameStarted?.Invoke();

	private void NotifyGameOver() => GameOvered?.Invoke();

	private void OnDisable()
	{
		GameQuited?.Invoke();
		_introducer.GameStarted -= NotifyStartGame;
		_bird.Collisioned -= NotifyGameOver;
		_restarter.GameRestarted += NotifyRestartGame;
	}
}
