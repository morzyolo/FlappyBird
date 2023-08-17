using UnityEngine;

public class Obstacle : MovingObject
{
	[SerializeField] private Pipe[] _pipes;

	private bool _isActive = true;

	public override void Reset() => Activate();

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
