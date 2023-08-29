using Cysharp.Threading.Tasks;
using System;

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
		await UniTask.WhenAny(fadeTask);

		GameRestarted?.Invoke();

		await _fading.FadeIn();
	}
}
