using Configs.Bird.Data;
using Cysharp.Threading.Tasks;
using SpriteChangers;
using System;
using System.Threading;
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
			if (!_flapAnimationTask.Status.IsCompleted())
			{
				CancelTokenSource();
				_spriteChanger.ChangeSprite(_animationData.DefaultFrame);
			}
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
					await UniTask.Delay(
						_animationData.FrameDelayMs,
						cancellationToken: _flapAnimationTokenSource.Token);
					_spriteChanger.ChangeSprite(animationFrames[i]);
				}
			}
		}

		private void CancelTokenSource()
		{
			_flapAnimationTokenSource?.Cancel();
			_flapAnimationTokenSource?.Dispose();
		}
	}
}
