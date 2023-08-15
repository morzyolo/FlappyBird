using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[SerializeField] private Pipe[] _pipes;

	private bool _isActive = true;

	public void Activate()
	{
		if (_isActive) return;

		foreach (var pipe in _pipes)
			pipe.Activate();

		_isActive = true;
	}

	public void Deactivate()
	{
		if (!_isActive) return;

		foreach (var pipe in _pipes)
			pipe.Deactivate();

		_isActive = false;
	}
}
