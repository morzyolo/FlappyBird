using System.Collections.Generic;
using UnityEngine;

public class PipesMover : MonoBehaviour, IUpdateListener
{
	private Updater _updater;
	private GameEventNotifier _notifier;

	private List<PipeObstacle> _obstacles;

	private float _endX;
	private float _xOffset;

	private float _pipeMoveSpeed;

	private float _maxHeight;
	private float _minHeight;

	public void Initialize(List<PipeObstacle> obstacles,
		PipesConfig config,
		Updater updater,
		GameEventNotifier notifier)
	{
		_obstacles = obstacles;

		ApplyConfig(config);

		_updater = updater;
		_notifier = notifier;

		_notifier.GameStarted += StartMovePipes;
		_notifier.GameOvered += StopMovePipes;
	}

	public void Tick(float deltaTime)
	{
		foreach (var obs in _obstacles)
		{
			obs.transform.Translate(_pipeMoveSpeed * Time.deltaTime * Vector3.left);

			if (obs.transform.position.x < _endX)
			{
				float newX = obs.transform.position.x + _obstacles.Count * _xOffset;
				float height = Random.Range(_minHeight, _maxHeight);
				obs.transform.position = new Vector3(newX, height, 0f);
			}
		}
	}

	private void ApplyConfig(PipesConfig config)
	{
		_endX = config.EndX;
		_xOffset = config.XOffset;
		_pipeMoveSpeed = config.PipeMoveSpeed;
		_maxHeight = config.MaxHeight;
		_minHeight = config.MinHeight;
	}

	private void StartMovePipes() => _updater.AddListener(this);

	private void StopMovePipes() => _updater.RemoveListener(this);

	private void OnDisable()
	{
		_notifier.GameStarted -= StartMovePipes;
		_notifier.GameOvered -= StopMovePipes;
	}
}
