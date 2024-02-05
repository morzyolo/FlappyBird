using UnityEngine.Events;
using UnityEngine.UI;

namespace Extensions
{
	public static class ButtonExtension
	{
		public static void AddListener(this Button button, UnityAction call)
			=> button.onClick.AddListener(call);

		public static void RemoveListener(this Button button, UnityAction call)
			=> button.onClick.RemoveListener(call);

		public static void SetActive(this Button button, bool value)
			=> button.gameObject.SetActive(value);
	}
}
