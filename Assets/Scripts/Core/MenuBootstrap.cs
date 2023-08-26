using System.Collections.Generic;
using UnityEngine;

public class MenuBootstrap : MonoBehaviour
{
	[Header("Configs")]
	[SerializeField] private FadeConfig _fadeConfig;
	[SerializeField] private SinusMovingObjectsConfig _menuObjectsConfig;
	[SerializeField] private HorizontalMovingObjectsConfig _groundsConfig;

	[Header("Core")]
	[SerializeField] private Updater _updater;

	[Header("Environment")]
	[SerializeField] private Transform _groundsContainer;
	[SerializeField] private RectTransform _menuObjectsContainer;

	[Header("UI")]
	[SerializeField] private MenuUI _menuUI;
	[SerializeField] private FadeImage _fadeImage;

	private Fading _fading;

	private void Awake()
	{
		_fading = new Fading(_fadeConfig, _fadeImage);
		var changer = new SceneChanger(_fading);
		_ = new Menu(_menuUI, changer);

		InitializeGroundsMover();
		_ = new MenuObjectsMover(_menuObjectsContainer, _menuObjectsConfig, _updater);
	}

	private void Start()
	{
		_fading.Start();
	}

	private void InitializeGroundsMover()
	{
		var grounds = CreateMovingObjects(_groundsConfig, _groundsContainer);

		var groundsSetter = new GroundsDefaultSetter(grounds, _groundsConfig);
		_ = new GroundsMover(grounds, groundsSetter, _groundsConfig, _updater);
	}

	private List<MovingObject> CreateMovingObjects(HorizontalMovingObjectsConfig config, Transform container)
		=> new MovingObjectsFactory(config).Create(container);
}
