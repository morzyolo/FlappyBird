using System.Collections.Generic;
using UnityEngine;

public class PipesMover : MonoBehaviour, IUpdateListener
{
	private Updater _updater;

	private List<Pipe> _pipes;

	private float _endX;
	private float _xOffset;

	private float _pipeMoveSpeed;

	private float _maxHeight;
	private float _minHeight;

	public void Initialize(List<Pipe> pipes, PipesConfig config, Updater updater)
	{
		_pipes = pipes;

		_endX = config.EndX;
		_xOffset = config.XOffset;
		_pipeMoveSpeed = config.PipeMoveSpeed;
		_maxHeight = config.MaxHeight;
		_minHeight = config.MinHeight;

		_updater = updater;
		_updater.AddListener(this);
	}

	public void Tick(float deltaTime)
	{
		foreach (var p in _pipes)
		{
			p.transform.Translate(_pipeMoveSpeed * Time.deltaTime * Vector3.left);

			if (p.transform.position.x < _endX)
			{
				float newX = p.transform.position.x + _pipes.Count * _xOffset;
				float height = Random.Range(_minHeight, _maxHeight);
				p.transform.position = new Vector3(newX, height, 0f);
			}
		}
	}
}
