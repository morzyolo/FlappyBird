using System;
using System.Threading.Tasks;

public class GameRestarter
{
	public event Action GameRestarted;

	private readonly Fading _fading;

	public GameRestarter(Fading fading)
	{
		_fading = fading;
	}

	public async void Restart()
	{
		var fadeTask = _fading.FadeOut();
		await Task.WhenAny(fadeTask);

		GameRestarted?.Invoke();

		await _fading.FadeIn();
	}
}
