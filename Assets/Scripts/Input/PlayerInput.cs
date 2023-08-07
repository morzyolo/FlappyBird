using UnityEngine;

public class PlayerInput : MonoBehaviour, IUpdateListener
{
	private Updater _updater;
	private Bird _bird;

	public void Initialize(Bird bird, Updater updater)
	{
		_bird = bird;
		_updater = updater;
		_updater.AddListener(this);
	}

	public void Tick(float deltaTime)
	{
		if (Input.GetKeyDown(KeyCode.Space))
			_bird.Flap();
	}

	private void OnDisable()
	{
		_updater.RemoveListener(this);
	}
}
