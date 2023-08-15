using System;

public class GameRestarter
{
	public event Action GameRestarted;

	public void Restart()
	{
		GameRestarted?.Invoke();
	}
}
