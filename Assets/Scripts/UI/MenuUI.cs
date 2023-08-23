using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
	[SerializeField] private Button _startButton;

	private Menu _menu;

	public void Initialize(Menu menu)
	{
		_menu = menu;
		_startButton.onClick.AddListener(StartGame);
	}

	private void StartGame()
	{
		_startButton.onClick.RemoveListener(StartGame);
		_menu.StartGame();
	}

	private void OnDisable()
	{
		_startButton.onClick.RemoveListener(StartGame);
	}
}
