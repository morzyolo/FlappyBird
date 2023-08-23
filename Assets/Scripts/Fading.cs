using System.Threading.Tasks;
using UnityEngine;

public class Fading
{
	private readonly FadeImage _fadeImage;
	private readonly float _fadeSpeed;

	public Fading(FadeConfig config, FadeImage fadeImage)
	{
		_fadeSpeed = config.FadeSpeed;
		_fadeImage = fadeImage;
	}

	public void Start()
	{
		_fadeImage.SetAlpha(1f);
		_ = FadeIn();
	}

	public async Task FadeIn() => await Fade(1f, 0f);

	public async Task FadeOut() => await Fade(0f, 1f);

	private async Task Fade(float startAlpha, float endAlpha)
	{
		float t = 0f;

		while (t < 1f)
		{
			t += Time.deltaTime * _fadeSpeed;
			_fadeImage.SetAlpha(Mathf.Lerp(startAlpha, endAlpha, t));
			await Task.Yield();
		}

		_fadeImage.SetAlpha(endAlpha);
	}
}
