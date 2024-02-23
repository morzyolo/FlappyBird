using UnityEngine;

namespace MovingObjects
{
	public class Ground : MonoBehaviour, IMovingObject, ICanKill
	{
		public float XPosition => transform.position.x;

		public void SetPosition(Vector3 position)
			=> transform.position = position;

		public void Translate(Vector3 translation)
			=> transform.Translate(translation);

		public void WithHeight(float height)
			=> transform.position.Set(XPosition, height, transform.position.z);
	}
}
