using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMover : IUpdateListener
{
	private readonly List<Obstacle> _obstacles;

	private readonly ObstaclesDefaultSetter _obstaclesSetter;
	private readonly GameEventNotifier _notifier;
	private readonly Updater _updater;

	private readonly float _endX;
	private readonly float _xOffset;
	private readonly float _pipeMoveSpeed;

	public ObstaclesMover(List<Obstacle> obstacles,
		ObstaclesDefaultSetter obstaclesSetter,
		GameEventNotifier notifier,
		Updater updater,
		PipesConfig config)
	{
		_obstacles = obstacles;
		_obstaclesSetter = obstaclesSetter;
		_updater = updater;
		_notifier = notifier;

		_endX = config.EndX;
		_xOffset = config.XOffset;
		_pipeMoveSpeed = config.PipeMoveSpeed;

		_notifier.GameStarted += StartMovePipes;
		_notifier.GameOvered += StopMovePipes;
		_notifier.GameQuited += Unsub;
	}

	public void Tick(float deltaTime)
	{
		foreach (var obs in _obstacles)
		{
			obs.transform.Translate(_pipeMoveSpeed * Time.deltaTime * Vector3.left);

			if (obs.transform.position.x < _endX)
			{
				float newX = obs.transform.position.x + _obstacles.Count * _xOffset;
				float height = _obstaclesSetter.GetRandomHeight();
				obs.transform.position = new Vector3(newX, height, 0f);
			}
		}
	}

	private void StartMovePipes() => _updater.AddListener(this);

	private void StopMovePipes() => _updater.RemoveListener(this);

	private void Unsub()
	{
		_notifier.GameStarted -= StartMovePipes;
		_notifier.GameOvered -= StopMovePipes;
		_notifier.GameQuited -= Unsub;
	}
}
