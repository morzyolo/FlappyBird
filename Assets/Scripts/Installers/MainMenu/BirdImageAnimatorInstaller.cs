using Bird.Components;
using Configs.Bird;
using SpriteChangers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers.MainMenu
{
	public class BirdImageAnimatorInstaller : MonoInstaller
	{
		[SerializeField] private Image _birdImage;
		[SerializeField] private BirdConfig _birdConfig;

		public override void InstallBindings()
		{
			BindSpriteChanger();
			BindBirdAnimator();
		}

		private void BindSpriteChanger()
		{
			Container
				.Bind<ISpriteChanger>()
				.To<ImageChanger>()
				.AsSingle()
				.WithArguments(_birdImage);
		}

		private void BindBirdAnimator()
		{
			Container
				.BindInterfacesAndSelfTo<BirdAnimator>()
				.AsSingle()
				.WithArguments(_birdConfig.AnimationData)
				.NonLazy();
		}
	}
}
