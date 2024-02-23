using System;
using Bird;
using UniRx;
using Zenject;

namespace Models
{
	public sealed class Score : IInitializable, IDisposable
	{
		public int CurrentScore => Value.Value;
		public ReactiveProperty<int> Value = new(0);

		private readonly BirdFacade _bird;

		private readonly CompositeDisposable _disposables = new();

		public Score(BirdFacade bird)
		{
			_bird = bird;
		}

		public void AddScore()
		{
			Value.Value++;
		}

		public void Reset()
		{
			Value.Value = 0;
		}

		public void Initialize()
		{
			_bird.ObstaclePassed
				.Subscribe(_ => AddScore())
				.AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
