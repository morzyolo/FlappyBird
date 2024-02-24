using Configs.Fade;
using Cysharp.Threading.Tasks;
using DG.Tweening;

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

		public async UniTask FadeIn() => await Fade(1f, 0f, false);

		public async UniTask FadeOut() => await Fade(0f, 1f, true);

		private async UniTask Fade(float startAlpha, float endAlpha, bool isBlock)
		{
			_fadeImage.IsBlockInput(isBlock);
			_fadeImage.SetAlpha(startAlpha);

			float currentAlpha = startAlpha;

			await DOTween.To(() => currentAlpha, value => currentAlpha = value, endAlpha, _config.FadeDuration)
				.OnUpdate(() => _fadeImage.SetAlpha(currentAlpha))
				.SetEase(Ease.InOutSine)
				.ToUniTask();

			_fadeImage.SetAlpha(endAlpha);
		}
	}
}
