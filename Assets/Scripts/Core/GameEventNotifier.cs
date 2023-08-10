using System;
using UnityEngine;

public class GameEventNotifier : MonoBehaviour
{
	public event Action GameStarted;
	public event Action GameOvered;

	private Bird _bird;
	private PreGameUI _preGameUI;

	public void Initialize(PreGameUI preGameUI, Bird bird)
	{
		_preGameUI = preGameUI;
		_bird = bird;

		_preGameUI.StartButtonPressed += NotifyStartGame;
		_bird.Collisioned += NotifyGameOver;
	}

	private void NotifyStartGame() => GameStarted?.Invoke();

	private void NotifyGameOver() => GameOvered?.Invoke();

	private void OnDisable()
	{
		_preGameUI.StartButtonPressed -= NotifyStartGame;
		_bird.Collisioned -= NotifyGameOver;
	}
}
