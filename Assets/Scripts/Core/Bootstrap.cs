using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private Bird _birdPrefab;
	[SerializeField] private BirdConfig _birdConfig;

	[SerializeField] private Updater _updater;
	[SerializeField] private PlayerInput _playerInput;

	private void Awake()
	{
		var birdFactory = new BirdFactory(_birdPrefab, _birdConfig);
		var bird = birdFactory.Create();

		_playerInput.Initialize(bird, _updater);
	}
}
