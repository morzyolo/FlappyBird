using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdFlapping : MonoBehaviour
{
	[SerializeField] private float _flapForce = 2f;

	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void Flap()
	{
		_rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(Vector2.up * _flapForce, ForceMode2D.Impulse);
	}
}
