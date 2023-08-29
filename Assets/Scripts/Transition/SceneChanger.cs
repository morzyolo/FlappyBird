using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class SceneChanger
{
	private readonly Fading _fading;

	public SceneChanger(Fading fading)
	{
		_fading = fading;
	}

	public async UniTask ChangeSceneAsync(string sceneName)
	{
		if (SceneManager.GetSceneByName(sceneName) == null)
			throw new System.Exception("Wrong scene name \"{sceneName}\"");

		await _fading.FadeOut();

		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}
