using System;
using System.Threading;
using Configs.Bird;
using Cysharp.Threading.Tasks;
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

			FlapTask(_cancellationSource.Token).Forget();
		}

		public void Reset()
		{
			_rigidbody.velocity = Vector2.zero;
		}

		public void SetBodyType(RigidbodyType2D type) => _rigidbody.bodyType = type;

		public void Dispose()
		{
			DisposeCancellationSource();
		}

		private async UniTask FlapTask(CancellationToken cancellationToken)
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
				await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);

				if (cancellationToken.IsCancellationRequested)
				{
					Debug.Log("Canceled");
					return;
				}

				_birdTurn.UpdateRotation();
			}
			while (_birdTurn.IsRotationRequired);
		}

		private void DisposeCancellationSource()
		{
			if (_cancellationSource != null)
			{
				_cancellationSource.Cancel();
				_cancellationSource.Dispose();
			}
		}
	}
}
