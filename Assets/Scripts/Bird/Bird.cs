using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField] private BirdConfig _config;

	[SerializeField] private BirdFlapping _birdFlapping;
	private BirdTurn _birdTurn;

	private void Awake()
	{
		_birdTurn = new BirdTurn(transform, _config);
		_birdFlapping.Initialize(_birdTurn, _config);
	}

	public void Flap() => _birdFlapping.Flap();
}
