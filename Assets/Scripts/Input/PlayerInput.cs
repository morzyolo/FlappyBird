using Bird;
using System;
using UI.Elements;
using Zenject;

namespace Input
{
	public sealed class PlayerInput : IInitializable, IDisposable
	{
		private readonly BirdFacade _bird;
		private readonly InputPanel _inputPanel;

		private bool _isEnable;

		public PlayerInput(BirdFacade bird, InputPanel inputPanel)
		{
			_bird = bird;
			_inputPanel = inputPanel;
		}

		public void Initialize()
		{
			_inputPanel.Clicked += FlapIfEnable;
		}

		public void Dispose()
		{
			_inputPanel.Clicked -= FlapIfEnable;
		}

		public void Enable() => SetIsEnable(true);

		public void Disable() => SetIsEnable(false);

		private void SetIsEnable(bool isEnable)
		{
			_isEnable = isEnable;
		}

		public void FlapIfEnable()
		{
			if (_isEnable)
				_bird.Flap();
		}
	}
}
