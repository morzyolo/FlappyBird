using Configs.Motion.Sinus;
using UnityEngine;

namespace ObjectMovers
{
	public class YSinusMover : IObjectMover
	{
		private readonly Transform _obj;
		private readonly SinusMotionConfig _config;

		private readonly float _startY;
		private readonly float _period;

		private float _currentSinAngle = 0f;

		public YSinusMover(Transform obj, SinusMotionConfig config)
		{
			_obj = obj;
			_config = config;

			_startY = _obj.position.y;
			_period = Mathf.PI * 2 / Mathf.Abs(_config.Speed);
		}

		public void Tick(float deltaTime)
		{
			_currentSinAngle += deltaTime;

			if (_currentSinAngle > _period)
				_currentSinAngle -= _period;

			Vector3 newPosition = _obj.position;
			newPosition.y = _startY + _config.YOffset * Mathf.Sin(_currentSinAngle * _config.Speed);
			_obj.position = newPosition;
		}
	}
}
