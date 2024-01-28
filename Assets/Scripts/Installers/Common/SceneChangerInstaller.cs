using Configs;
using Transition;
using UI.Elements;
using UnityEngine;
using Zenject;

namespace Installers.Common
{
	public class SceneChangerInstaller : MonoInstaller
	{
		[SerializeField] private FadeImage _fadeImage;
		[SerializeField] private FadeConfig _fadeConfig;

		public override void InstallBindings()
		{
			BindFadingScreen();
			BindSceneChanger();
		}

		private void BindFadingScreen()
		{
			Container
				.BindInstance(_fadeImage)
				.AsSingle();

			Container
				.Bind<FadingScreen>()
				.AsSingle()
				.WithArguments(_fadeConfig);
		}

		private void BindSceneChanger()
		{
			Container
				.BindInterfacesAndSelfTo<SceneChanger>()
				.AsSingle();
		}
	}
}