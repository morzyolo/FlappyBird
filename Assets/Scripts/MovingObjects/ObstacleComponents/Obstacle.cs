using UnityEngine;

namespace MovingObjects.ObstacleComponents
{
	public class Obstacle : MonoBehaviour, IMovingObject, ICanKill
	{
		public float XPosition => transform.position.x;

		[SerializeField] private Pipe[] _pipes;

		private readonly float _maxBorder = 14f;
		private readonly float _minBorder = -7f;

		public void SetPosition(Vector3 position)
		{
			transform.position = position;

			SetActive(true);

			for (int i = 0; i < _pipes.Length; i++)
				_pipes[i].UpdateSize((_minBorder, _maxBorder), position.y);
		}

		public void Translate(Vector3 translation)
			=> transform.Translate(translation);

		public void WithHeight(float height)
			=> transform.position.Set(XPosition, height, transform.position.z);

		private void SetActive(bool isActive)
		{
			foreach (var pipe in _pipes)
				pipe.SetActive(isActive);
		}
	}
}
