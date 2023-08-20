using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BirdAnimator : MonoBehaviour
{
	[SerializeField] private string _flappingBoolName = "IsFlapping";

	private BirdCrossingDetector _detector;

	private Animator _animator;

	private void Awake() => _animator = GetComponent<Animator>();

	public void Initialize(BirdCrossingDetector detector)
	{
		_detector = detector;

		StartFlapping();
		_detector.Collisioned += StopFlapping;
	}

	private void StopFlapping() => _animator.SetBool(_flappingBoolName, false);

	public void StartFlapping() => _animator.SetBool(_flappingBoolName, true);

	private void OnDisable() => _detector.Collisioned -= StopFlapping;
}
