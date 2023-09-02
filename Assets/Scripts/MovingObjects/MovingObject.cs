using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
	public virtual void Reset() { }

	public virtual void SetPosition (Vector3 position) => transform.position = position;
}
