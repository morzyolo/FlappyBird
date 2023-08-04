using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	[SerializeField] private BirdFlapping _bird;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			_bird.Flap();
		}
	}
}
