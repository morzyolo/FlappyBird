using UnityEngine;

public class Obstacle : MovingObject
{
	private readonly float _maxBorder = 13f;
	private readonly float _minBorder = -7f;

	[SerializeField] private Pipe[] _pipes;

	private bool _isActive = true;

	public override void Reset() => Activate();

	public override void SetPosition(Vector3 position)
	{
		base.SetPosition(position);

		for (int i = 0 ; i < _pipes.Length; i++)
			_pipes[i].UpdateSize((_minBorder, _maxBorder), position.y);
	}

	public void Deactivate()
	{
		if (!_isActive) return;

		foreach (var pipe in _pipes)
			pipe.Deactivate();

		_isActive = false;
	}

	private void Activate()
	{
		if (_isActive) return;

		foreach (var pipe in _pipes)
			pipe.Activate();

		_isActive = true;
	}
}
