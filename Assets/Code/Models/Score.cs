using Bird;
using System;
using Zenject;

namespace Models
{
	public sealed class Score : IInitializable, IDisposable
	{
		public event Action<int> OnValueChanged;

		private readonly BirdFacade _bird;

		public int CurrentScore => _currentScore;
		private int _currentScore = 0;

		public Score(BirdFacade bird)
		{
			_bird = bird;
		}

		public void AddScore()
		{
			_currentScore++;
			OnValueChanged?.Invoke(_currentScore);
		}

		public void Reset()
		{
			_currentScore = 0;
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
