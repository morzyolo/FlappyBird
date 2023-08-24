using UnityEngine;

[CreateAssetMenu(menuName = "MovingObjectsConfig/Sinus", order = 2)]
public class SinusMovingObjectsConfig : ScriptableObject
{
	public float StartY { get => _startY; }
	public float YOffset { get => _yOffset; }
	public float Speed { get => _speed; }

	[SerializeField] private float _startY = 0f;
	[SerializeField] private float _yOffset = 1f;
	[SerializeField] private float _speed = 1f;
}
