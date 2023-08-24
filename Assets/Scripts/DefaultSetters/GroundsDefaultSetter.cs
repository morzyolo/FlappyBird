using System.Collections.Generic;

public class GroundsDefaultSetter : DefaultSetter
{
	private readonly float _height;

	public GroundsDefaultSetter(List<MovingObject> grounds, HorizontalMovingObjectsConfig config,
		GameEventNotifier notifier)
		: base (grounds, config, notifier)
	{
		_height = config.MaxHeight;
		Place();
	}

	public override float GetHeight() => _height;
}
