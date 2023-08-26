using System.Collections.Generic;

public class GroundsDefaultSetter : DefaultSetter
{
	private readonly GameEventNotifier _notifier;

	private readonly float _height;

	public GroundsDefaultSetter(
		List<MovingObject> grounds,
		HorizontalMovingObjectsConfig config,
		GameEventNotifier notifier = null)
		: base (grounds, config)
	{
		_notifier = notifier;
		if (notifier != null)
			Sub();

		_height = config.MaxHeight;

		Place();
	}

	public override float GetHeight() => _height;

	private void Sub()
	{
		_notifier.GameRestarted += Place;
		_notifier.GameQuited += Unsub;
	}

	private void Unsub()
	{
		_notifier.GameRestarted -= Place;
		_notifier.GameQuited -= Unsub;
	}
}
