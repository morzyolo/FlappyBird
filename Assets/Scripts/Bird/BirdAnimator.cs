using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BirdAnimator : MonoBehaviour
{
	[SerializeField] private string StopFlapTriggerName = "IsCollisioned";

	private Animator _animator;

	private BirdCrossingDetector _detector;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public void Initialize(BirdCrossingDetector detector)
	{
		_detector = detector;
		_detector.Collisioned += StopFlapAnimation;
	}

	private void StopFlapAnimation()
	{
		_detector.Collisioned -= StopFlapAnimation;
		_animator.SetTrigger(StopFlapTriggerName);
	}
}
