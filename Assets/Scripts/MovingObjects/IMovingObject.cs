using UnityEngine;

namespace MovingObjects
{
	public interface IMovingObject
	{
		public float XPosition { get; }

		public void SetPosition(Vector3 position);
		public void Translate(Vector3 translation);
		public void WithHeight(float height);
	}
}
