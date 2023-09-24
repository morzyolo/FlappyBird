using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class BirdAnimator : IDisposable
{
	private readonly SpriteChanger _spriteChanger;

	private readonly int _frameDelayMs;
	private readonly Sprite _defaultFrame;
	private readonly Sprite[] _flapFrames;

	private UniTask _flapAnimationTask;
	private CancellationTokenSource _flapAnimationTokenSource;

	public BirdAnimator(SpriteChanger spriteChanger, BirdConfig config)
	{
		_spriteChanger = spriteChanger;

		_frameDelayMs = config.FrameDelayMs;
		_defaultFrame = config.DefaultFrame;
		_flapFrames = config.FlapFrames;

		_spriteChanger.ChangeSprite(_defaultFrame);

		_flapAnimationTokenSource?.Dispose();
		_flapAnimationTokenSource = new CancellationTokenSource();
	}

	public void Dispose() => CancelTokenSource();

	public void StopFlapping()
	{
		if (!_flapAnimationTask.Status.IsCompleted())
		{
			CancelAnimation();
			_spriteChanger.ChangeSprite(_defaultFrame);
		}
	}

	public void StartFlapping()
	{
		if (_flapAnimationTask.Status.IsCompleted())
			_flapAnimationTask = PlayFlapAnimation();
	}

	private async UniTask PlayFlapAnimation()
	{
		int framesCount = _flapFrames.Length;

		while (!_flapAnimationTokenSource.IsCancellationRequested)
		{
			for (int i = 0; i < framesCount; i++)
			{
				await UniTask.Delay(_frameDelayMs, cancellationToken: _flapAnimationTokenSource.Token);
				_spriteChanger.ChangeSprite(_flapFrames[i]);
			}
		}
	}

	private void CancelAnimation()
	{
		CancelTokenSource();
		_flapAnimationTokenSource = new CancellationTokenSource();
	}

	private void CancelTokenSource()
	{
		_flapAnimationTokenSource.Cancel();
		_flapAnimationTokenSource.Dispose();
	}
}
