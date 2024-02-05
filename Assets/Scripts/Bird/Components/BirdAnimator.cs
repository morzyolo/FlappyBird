using System;
using System.Threading;
using Configs.Bird.Data;
using Cysharp.Threading.Tasks;
using SpriteChangers;
using UnityEngine;
using Zenject;

namespace Bird.Components
{
	public sealed class BirdAnimator : IDisposable, IInitializable
	{
		private readonly ISpriteChanger _spriteChanger;
		private readonly BirdAnimationData _animationData;

		private UniTask _flapAnimationTask;
		private CancellationTokenSource _flapAnimationTokenSource;

		public BirdAnimator(ISpriteChanger spriteChanger, BirdAnimationData animationData)
		{
			_spriteChanger = spriteChanger;
			_animationData = animationData;
		}

		public void Initialize()
		{
			if (_flapAnimationTokenSource != null)
				CancelTokenSource();

			StartFlapping();
		}

		public void StartFlapping()
		{
			if (_flapAnimationTask.Status.IsCompleted())
			{
				_flapAnimationTokenSource = new CancellationTokenSource();
				_flapAnimationTask = PlayFlapAnimation();
			}
		}

		public void StopFlapping()
		{
			CancelTokenSource();
			_spriteChanger.ChangeSprite(_animationData.DefaultFrame);
		}

		public void Dispose()
		{
			CancelTokenSource();
		}

		private async UniTask PlayFlapAnimation()
		{
			Sprite[] animationFrames = _animationData.FlapFrames;

			int framesCount = animationFrames.Length;

			while (!_flapAnimationTokenSource.IsCancellationRequested)
			{
				for (int i = 0; i < framesCount; i++)
				{
					_spriteChanger.ChangeSprite(animationFrames[i]);
					await UniTask.Delay(
						_animationData.FrameDelayMs,
						cancellationToken: _flapAnimationTokenSource.Token);

					if (_flapAnimationTokenSource.IsCancellationRequested)
						return;
				}
			}
		}

		private void CancelTokenSource()
		{
			if (_flapAnimationTokenSource != null
				&& !_flapAnimationTokenSource.IsCancellationRequested)
			{
				_flapAnimationTokenSource.Cancel();
				_flapAnimationTokenSource.Dispose();
			}
		}
	}
}
