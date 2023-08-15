using System;
using UnityEngine;

public class GameEventNotifier : MonoBehaviour
{
	public event Action GameStarted;
	public event Action GameOvered;
	public event Action GameQuited;

	private Bird _bird;
	private GameIntroducer _introducer;

	public void Initialize(Bird bird, GameIntroducer introducer)
	{
		_bird = bird;
		_introducer = introducer;

		_introducer.GameStarted += NotifyStartGame;
		_bird.Collisioned += NotifyGameOver;
	}

	private void NotifyStartGame() => GameStarted?.Invoke();

	private void NotifyGameOver() => GameOvered?.Invoke();

	private void OnDisable()
	{
		GameQuited?.Invoke();
		_introducer.GameStarted -= NotifyStartGame;
		_bird.Collisioned -= NotifyGameOver;
	}
}
