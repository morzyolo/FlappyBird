using Bird.Components;
using Configs;
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
				.BindInterfacesTo<BirdAnimator>()
				.AsSingle()
				.WithArguments(_birdConfig.AnimationData)
				.NonLazy();
		}
	}
}
