using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdFlapping : MonoBehaviour
{
	private Rigidbody2D _rigidbody;

	private BirdTurn _birdTurn;
	private float _flapForce;
	private Vector2 _flapOffset;

	private Coroutine _currentFlap;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void Initialize(BirdTurn birdTurn, BirdConfig config)
	{
		_birdTurn = birdTurn;
		_flapForce = config.FlapForce;
		_flapOffset = config.FlapOffset;
	}

	public void Flap()
	{
		if (_currentFlap != null)
			StopCoroutine(_currentFlap);

		_currentFlap = StartCoroutine(FlapCoroutine());
	}

	private IEnumerator FlapCoroutine()
	{
		Vector3 flapPosition = transform.position;
		flapPosition.x += _flapOffset.x;
		flapPosition.y += _flapOffset.y;
		_birdTurn.FlapPosition = flapPosition;

		_rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(Vector2.up * _flapForce, ForceMode2D.Impulse);

		do
		{
			yield return null;
			_birdTurn.UpdateRotation();
		}
		while (_birdTurn.IsRotationRequired);
	}
}
