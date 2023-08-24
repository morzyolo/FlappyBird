public abstract class ObjectsMover : IUpdateListener
{
	private readonly Updater _updater;

	public ObjectsMover(Updater updater)
	{
		_updater = updater;
	}

	public abstract void Tick(float deltaTime);

	protected void StartMoveObjects() => _updater.AddListener(this);

	protected void StopMoveObjects() => _updater.RemoveListener(this);
}
