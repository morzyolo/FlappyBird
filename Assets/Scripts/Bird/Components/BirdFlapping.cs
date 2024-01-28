using Configs.Bird;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace Bird.Components
{
	public sealed class BirdFlapping : IDisposable
	{
		public event Action Flapped;

		private readonly Transform _transform;
		private readonly Rigidbody2D _rigidbody;
		private readonly BirdConfig _config;
		private readonly BirdTurn _birdTurn;

		private UniTask _flapTask;
		private CancellationTokenSource _cancellationSource;

		public BirdFlapping(
			Transform transform,
			Rigidbody2D rigidbody,
			BirdConfig config,
			BirdTurn turn)
		{
			_transform = transform;
			_rigidbody = rigidbody;
			_config = config;
			_birdTurn = turn;
		}

		public void Flap()
		{
			DisposeCancellationSource();

			_cancellationSource = new CancellationTokenSource();

			_flapTask = FlapTask();
		}

		public void Reset()
		{
			_rigidbody.velocity = Vector2.zero;

			if (_flapTask.Status.IsCompleted())
				_cancellationSource.Cancel();
		}

		public void SetBodyType(RigidbodyType2D type) => _rigidbody.bodyType = type;

		public void Dispose()
		{
			DisposeCancellationSource();
		}

		private async UniTask FlapTask()
		{
			Vector3 flapPosition = _transform.position;
			flapPosition.x += _config.FlapOffset.x;
			flapPosition.y += _config.FlapOffset.y;
			_birdTurn.SetFlapPosition(flapPosition);

			_rigidbody.velocity = Vector3.zero;
			_rigidbody.AddForce(Vector2.up * _config.FlapForce, ForceMode2D.Impulse);
			Flapped?.Invoke();

			do
			{
				await UniTask.Yield(PlayerLoopTiming.Update, _cancellationSource.Token);
				_birdTurn.UpdateRotation();
			}
			while (_birdTurn.IsRotationRequired && !_cancellationSource.IsCancellationRequested);
		}

		private void DisposeCancellationSource()
		{
			_cancellationSource?.Cancel();
			_cancellationSource?.Dispose();
		}
	}
}
