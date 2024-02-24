using UnityEngine;

namespace Configs.Motion
{
	[CreateAssetMenu(menuName = "MovingObjectsConfig/Sinus", order = 2)]
	public class SinusMotionConfig : ScriptableObject
	{
		public float YOffset => _yOffset;
		public float Speed => _speed;

		[SerializeField] private float _yOffset = 1f;
		[SerializeField] private float _speed = 1f;
	}
}
