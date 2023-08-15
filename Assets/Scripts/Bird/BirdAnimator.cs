using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BirdAnimator : MonoBehaviour
{
	[SerializeField] private string StopFlapTriggerName = "IsCollisioned";
	[SerializeField] private string ResetTriggerName = "IsReseted";

	private Animator _animator;

	private BirdCrossingDetector _detector;

	private void Awake() => _animator = GetComponent<Animator>();

	public void Initialize(BirdCrossingDetector detector)
	{
		_detector = detector;

		_detector.Collisioned += StopFlapAnimation;
	}

	private void StopFlapAnimation() => _animator.SetTrigger(StopFlapTriggerName);

	public void Reset() => _animator.SetTrigger(ResetTriggerName);

	private void OnDisable() => _detector.Collisioned -= StopFlapAnimation;
}
