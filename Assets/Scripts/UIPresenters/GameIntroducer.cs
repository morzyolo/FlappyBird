using System;

public class GameIntroducer : IDisposable
{
	public event Action GameStarted;

	private readonly PreGameUI _ui;
	private readonly GameEventNotifier _notifier;

	public GameIntroducer(PreGameUI preGameUI, GameEventNotifier notifier)
	{
		_ui = preGameUI;
		_notifier = notifier;

		_ui.Initialize(this);

		_notifier.GameRestarted += Show;
		_notifier.AddDisposable(this);
		Show();
	}

	public void NotifyStartGame()
	{
		_ui.Hide();
		GameStarted?.Invoke();
	}

	public void Dispose()
	{
		_notifier.GameRestarted -= Show;
	}

	private void Show() => _ui.Show();
}
