using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
	public class InputPanel : MonoBehaviour, IPointerDownHandler
	{
		public event Action Clicked;

		[SerializeField] private Image _input;

		public void OnPointerDown(PointerEventData eventData)
			=> Clicked?.Invoke();

		public void IsEnable(bool isEnable)
		{
			_input.raycastTarget = isEnable;
		}
	}
}
