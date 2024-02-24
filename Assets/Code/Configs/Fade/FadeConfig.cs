using UnityEngine;

namespace Configs.Fade
{
	[CreateAssetMenu(menuName = "FadeConfig", order = 3)]
	public class FadeConfig : ScriptableObject
	{
		public float FadeDuration => _fadeDuration;

		[SerializeField] private float _fadeDuration = 2.2f;
	}
}
