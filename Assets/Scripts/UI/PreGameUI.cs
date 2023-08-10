using System;
using UnityEngine;
using UnityEngine.UI;

public class PreGameUI : MonoBehaviour
{
	public event Action StartButtonPressed;

	[SerializeField] private Button _startButton;

	private void NotifyStart()
	{
		StartButtonPressed?.Invoke();
		_startButton.onClick.RemoveListener(NotifyStart);
		_startButton.gameObject.SetActive(false);
	}

	private void OnEnable() => _startButton.onClick.AddListener(NotifyStart);

	private void OnDisable() => _startButton.onClick.RemoveListener(NotifyStart);
}
