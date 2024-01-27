using UnityEngine;

namespace Configs
{
	[CreateAssetMenu(menuName = "FadeConfig", order = 3)]
	public class FadeConfig : ScriptableObject
	{
		public float FadeSpeed { get => _fadeSpeed; }

		[SerializeField] private float _fadeSpeed = 2.2f;
	}
}
