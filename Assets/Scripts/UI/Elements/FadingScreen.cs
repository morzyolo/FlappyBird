using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Elements
{
	public class FadingScreen
	{
		private readonly FadeImage _fadeImage;
		private readonly FadeConfig _config;

		public FadingScreen(FadeImage fadeImage, FadeConfig config)
		{
			_fadeImage = fadeImage;
			_config = config;
		}

		public async UniTask FadeIn() => await Fade(1f, 0f);

		public async UniTask FadeOut() => await Fade(0f, 1f);

		private async UniTask Fade(float startAlpha, float endAlpha)
		{
			_fadeImage.SetAlpha(startAlpha);
			float time = 0f;

			while (time < _config.FadeDuration)
			{
				time += Time.deltaTime;

				float alpha = Mathf.Lerp(startAlpha, endAlpha, time / _config.FadeDuration);
				_fadeImage.SetAlpha(alpha);

				await UniTask.Yield(PlayerLoopTiming.Update);
			}

			_fadeImage.SetAlpha(endAlpha);
		}
	}
}
