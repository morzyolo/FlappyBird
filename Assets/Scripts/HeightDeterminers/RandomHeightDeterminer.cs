using UnityEngine;

namespace HeightDeterminers
{
	public class RandomHeightDeterminer : IHeightDeterminer
	{
		public float Height => Random.Range(_minHeight, _maxHeight);

		private readonly float _minHeight;
		private readonly float _maxHeight;

		public RandomHeightDeterminer(float minHeight, float maxHeight)
		{
			_minHeight = minHeight;
			_maxHeight = maxHeight;
		}
	}
}
