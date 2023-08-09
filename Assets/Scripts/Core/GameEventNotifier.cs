using System;
using UnityEngine;

public class GameEventNotifier : MonoBehaviour
{
	public event Action GameOvered;

	private Bird _bird;

	public void Initialize(Bird bird)
	{
		_bird = bird;

		_bird.Collisioned += NotifyGameOver;
	}

	private void NotifyGameOver() => GameOvered?.Invoke();

	private void OnDisable()
	{
		_bird.Collisioned -= NotifyGameOver;
	}
}
