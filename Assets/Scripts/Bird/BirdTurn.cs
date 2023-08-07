using UnityEngine;

public class BirdTurn
{
	public bool IsRotationRequired { get; private set; }

	public Vector3 FlapPosition { private get; set; }

	private readonly Transform _birdTransform;

	private readonly float _maxRotationAngle;
	private readonly float _minRotationAngle;

	public BirdTurn(Transform birdTransform, BirdConfig config)
	{
		_birdTransform = birdTransform;
		_maxRotationAngle = config.MaxRotationAngle;
		_minRotationAngle = config.MinRotationAngle;
	}

	public void UpdateRotation()
	{
		var direction = _birdTransform.position - FlapPosition;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		IsRotationRequired = angle > _minRotationAngle;

		angle = Mathf.Clamp(angle, _minRotationAngle, _maxRotationAngle);
		_birdTransform.rotation = Quaternion.Euler(0f, 0f, angle);
	}
}
