using Configs.Motion;
using UnityEngine;

namespace ObjectMovers
{
	public class YSinusMover : IObjectMover
	{
		private readonly Transform _transform;
		private readonly SinusMotionConfig _config;

		private readonly float _startY;
		private readonly float _period;

		private float _currentSinAngle = 0f;

		public YSinusMover(Transform transform, SinusMotionConfig config)
		{
			_transform = transform;
			_config = config;

			_startY = _transform.position.y;
			_period = Mathf.PI * 2 / Mathf.Abs(_config.Speed);
		}

		public void Tick(float deltaTime)
		{
			_currentSinAngle += deltaTime;

			if (_currentSinAngle > _period)
				_currentSinAngle -= _period;

			Vector3 newPosition = _transform.position;
			newPosition.y = _startY + _config.YOffset * Mathf.Sin(_currentSinAngle * _config.Speed);
			_transform.position = newPosition;
		}
	}
}
