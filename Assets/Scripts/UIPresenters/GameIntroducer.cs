using System;

public class GameIntroducer
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
		_notifier.GameQuited += Unsub;
		Show();
	}


	public void NotifyStartGame()
	{
		_ui.Hide();
		GameStarted?.Invoke();
	}

	private void Show() => _ui.Show();

	private void Unsub()
	{
		_notifier.GameRestarted -= Show;
		_notifier.GameQuited -= Unsub;
	}
}
