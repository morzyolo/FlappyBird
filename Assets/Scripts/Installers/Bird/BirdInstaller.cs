using Bird.Components;
using Configs.Bird;
using SpriteChangers;
using UnityEngine;
using Zenject;

namespace Installers.Bird
{
	public class BirdInstaller : MonoInstaller
	{
		[SerializeField] private BirdConfig _config;

		[SerializeField] private Transform _birdRoot;
		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private AudioSource _audioSource;

		[SerializeField] private BirdCrossingDetector _crossingDetector;

		public override void InstallBindings()
		{
			BindCrossingDetector();
			BindTurn();
			BindSpriteChanger();
			BindAnimator();
			BindFlapping();
			BindAudioSource();
		}

		private void BindCrossingDetector()
		{
			Container
				.BindInstance(_crossingDetector)
				.AsSingle();
		}

		private void BindTurn()
		{
			Container
				.Bind<BirdTurn>()
				.To<BirdTurn>()
				.AsSingle()
				.WithArguments(_birdRoot, _config);
		}

		private void BindSpriteChanger()
		{
			Container
				.Bind<ISpriteChanger>()
				.To<SpriteRendererChanger>()
				.AsSingle()
				.WithArguments(_spriteRenderer);
		}

		private void BindAnimator()
		{
			Container
				.BindInterfacesAndSelfTo<BirdAnimator>()
				.AsSingle()
				.WithArguments(_config.AnimationData);
		}

		private void BindFlapping()
		{
			Container
				.BindInterfacesAndSelfTo<BirdFlapping>()
				.AsSingle()
				.WithArguments(_birdRoot, _rigidbody, _config);
		}

		private void BindAudioSource()
		{
			Container
				.BindInterfacesAndSelfTo<BirdAudioSource>()
				.AsSingle()
				.WithArguments(_audioSource, _config);
		}
	}
}
