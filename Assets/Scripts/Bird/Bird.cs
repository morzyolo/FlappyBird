using UnityEngine;

public class Bird : MonoBehaviour
{
	[SerializeField] private BirdFlapping _birdFlapping;

	private BirdTurn _birdTurn;

	public void Initialize(BirdConfig config)
	{
		_birdTurn = new BirdTurn(transform, config);
		_birdFlapping.Initialize(_birdTurn, config);
	}

	public void Flap() => _birdFlapping.Flap();
}
