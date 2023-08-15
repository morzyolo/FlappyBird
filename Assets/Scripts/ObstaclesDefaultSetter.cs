using System.Collections.Generic;
using UnityEngine;

public class ObstaclesDefaultSetter
{
	private readonly List<Obstacle> _obstacles;
	private readonly GameEventNotifier _notifier;

	private readonly float _startX;
	private readonly float _xOffset;

	private readonly float _maxHeight;
	private readonly float _minHeight;

	public ObstaclesDefaultSetter(List<Obstacle> obstacles, GameEventNotifier notifier, PipesConfig config)
	{
		_obstacles = obstacles;
		_notifier = notifier;

		_startX = config.StartX;
		_xOffset = config.XOffset;
		_maxHeight = config.MaxHeight;
		_minHeight = config.MinHeight;

		_notifier.GameRestarted += Place;
		_notifier.GameQuited += Unsub;
		Place();
	}

	public float GetRandomHeight() => Random.Range(_minHeight, _maxHeight);

	private void Place()
	{
		var spawnPosition = new Vector3(_startX, 0f, 0f);

		for (int i = 0; i < _obstacles.Count; i++)
		{
			spawnPosition.y = GetRandomHeight();
			_obstacles[i].transform.position = spawnPosition;
			_obstacles[i].Activate();
			spawnPosition.x += _xOffset;
		}
	}

	private void Unsub()
	{
		_notifier.GameRestarted -= Place;
		_notifier.GameQuited -= Unsub;
	}
}
