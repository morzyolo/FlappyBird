using Bird;
using System;

namespace Models
{
	public sealed class Score : IDisposable
	{
		public event Action<int> OnValueChanged;

		private readonly BirdFacade _bird;

		public int CurrentScore => _currentScore;
		private int _currentScore = 0;

		public Score(BirdFacade bird)
		{
			_bird = bird;

			_bird.ObstaclePassed += AddScore;
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

		public void Dispose()
		{
			_bird.ObstaclePassed -= AddScore;
		}
	}
}
