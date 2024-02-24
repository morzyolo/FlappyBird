using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.SceneReference;

namespace Code.Bootstrap
{
	public class BootstrapHelper : MonoBehaviour
	{
		[SerializeField] private SceneReference _menuScene;

		private void Start()
		{
			SceneManager.LoadScene(_menuScene.ScenePath, LoadSceneMode.Single);
		}
	}
}
