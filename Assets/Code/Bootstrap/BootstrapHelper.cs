using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Bootstrap
{
	public class BootstrapHelper : MonoBehaviour
	{
		[SerializeField] private SceneAsset _menuScene;

		private void Start()
			=> SceneManager.LoadScene(_menuScene.name, LoadSceneMode.Single);
	}
}
