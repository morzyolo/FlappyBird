using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Elements
{
	public class InputPanel : MonoBehaviour, IPointerDownHandler
	{
		public event Action Clicked;

		public void OnPointerDown(PointerEventData eventData)
			=> Clicked?.Invoke();
	}
}
