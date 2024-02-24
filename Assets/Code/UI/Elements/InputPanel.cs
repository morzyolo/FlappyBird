using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
	public class InputPanel : MonoBehaviour, IPointerDownHandler
	{
		public ReactiveCommand Clicked { get; } = new();

		[SerializeField] private Image _input;

		public void OnPointerDown(PointerEventData eventData)
			=> Clicked.Execute();

		public void IsEnable(bool isEnable)
		{
			_input.raycastTarget = isEnable;
		}
	}
}
