using UnityEngine;

public class PipeObstacle : MonoBehaviour
{
	[SerializeField] private Pipe[] _pipes;

	public void Deactivate()
	{
		foreach (Pipe pipe in _pipes)
			pipe.Deactivate();
	}
}
