using System.Collections.Generic;
using UnityEngine;

public class BirdPreGameMover : ObjectSinusMover
{
	private readonly Bird _bird;
	private readonly GameEventNotifier _notifier;

	public BirdPreGameMover(
		Bird bird,
		GameEventNotifier notifier,
		BirdConfig config,
		Updater updater)
		: base (new List<Transform>() { bird.transform }, config.SinusMovingObjectsConfig, updater)
	{
		_bird = bird;
		_notifier = notifier;

		_notifier.GameRestarted += Reset;
		_notifier.GameStarted += StopMove;
		_notifier.GameQuited += Unsub;
		StartMove();
	}

	private void StartMove()
	{
		_bird.MakeNonPhisical();
		StartMoveObjects();
	}

	private void Reset()
	{
		_bird.Reset();
		StartMove();
	}

	private void StopMove()
	{
		StopMoveObjects();
		_bird.MakePhisical();
	}

	private void Unsub()
	{
		_notifier.GameRestarted -= Reset;
		_notifier.GameStarted -= StopMove;
		_notifier.GameQuited -= Unsub;
	}
}
