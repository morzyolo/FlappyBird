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
		{
			_notifier.GameRestarted += Place;
			_notifier.AddDisposable(this);
		}

		_height = config.MaxHeight;

		Place();
	}

	public override float GetHeight() => _height;

	public override void Dispose()
	{
		_notifier.GameRestarted -= Place;
	}
}
