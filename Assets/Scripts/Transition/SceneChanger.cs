using Cysharp.Threading.Tasks;
using UI.Elements;
using UnityEngine.SceneManagement;
using Zenject;

namespace Transition
{
	public class SceneChanger : IInitializable
	{
		private readonly FadingScreen _fading;

		public SceneChanger(FadingScreen fading)
		{
			_fading = fading;
		}

		public async void Initialize()
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
