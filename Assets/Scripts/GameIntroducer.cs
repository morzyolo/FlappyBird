using System;

public class GameIntroducer
{
	public event Action GameStarted;

	private readonly PreGameUI _ui;

	public GameIntroducer(PreGameUI preGameUI)
	{
		_ui = preGameUI;
		_ui.Initialize(this);
		_ui.Show();
	}

	public void NotifyStartGame()
	{
		_ui.Hide();
		GameStarted?.Invoke();
	}
}
