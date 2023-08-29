using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
	private SpriteChanger _spriteChanger;

	private int _frameDelayMs;
	private Sprite _defaultFrame;
	private Sprite[] _flapFrames;

	private UniTask _flapAnimationTask;
	private CancellationTokenSource _flapAnimationTokenSource;

	public void Initialize(SpriteChanger spriteChanger, BirdConfig config)
	{
		_spriteChanger = spriteChanger;

		_frameDelayMs = config.FrameDelayMs;
		_defaultFrame = config.DefaultFrame;
		_flapFrames = config.FlapFrames;

		_spriteChanger.ChangeSprite(_defaultFrame);
	}

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

	private void OnEnable()
	{
		_flapAnimationTokenSource?.Dispose();
		_flapAnimationTokenSource = new CancellationTokenSource();
	}

	private void OnDisable()
	{
		CancelTokenSource();
	}
}
