using Cysharp.Threading.Tasks;
using UI.Elements;
using UnityEngine.SceneManagement;

namespace Transition
{
	public class SceneChanger
	{
		private readonly FadingScreen _fading;

		public SceneChanger(FadingScreen fading)
		{
			_fading = fading;
		}

		public async UniTask ShowScreen()
		{
			await _fading.FadeIn();
		}

		public async UniTask ChangeSceneAsync(string sceneName)
		{
			await _fading.FadeOut();

			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
	}
}
