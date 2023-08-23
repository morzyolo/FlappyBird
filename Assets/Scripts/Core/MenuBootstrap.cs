using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private FadeConfig _fadeConfig;

	[Header("UI")]
	[SerializeField] private MenuUI _menuUI;
	[SerializeField] private FadeImage _fadeImage;

	private Fading _fading;

	private void Awake()
	{
		_fading = new Fading(_fadeConfig, _fadeImage);
		var changer = new SceneChanger(_fading);
		var menu = new Menu(_menuUI, changer);
	}

	private void Start()
	{
		_fading.Start();
	}
}
