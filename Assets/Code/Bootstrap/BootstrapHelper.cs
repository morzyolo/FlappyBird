using SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Bootstrap
{
	public class BootstrapHelper : MonoBehaviour
	{
		[SerializeField] private SceneRef _menuScene;

		private void Start()
		{
			SceneManager.LoadScene(_menuScene, LoadSceneMode.Single);
		}
	}
}
