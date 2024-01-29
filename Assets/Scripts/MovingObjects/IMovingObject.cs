using UnityEngine;

namespace MovingObjects
{
	public interface IMovingObject
	{
		public void Translate(Vector3 translation);
		public void SetPosition(Vector3 position);
	}
}
