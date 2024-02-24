using System;
using Bird;
using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using UI.Elements;
using UniRx;
using Zenject;

namespace Input
{
	public sealed class PlayerInput : IInitializable, IDisposable
	{
		private readonly CompositeDisposable _disposables = new();

		private readonly BirdFacade _bird;
		private readonly InputPanel _inputPanel;
		private readonly State _state;

		private bool _isEnable;

		public PlayerInput(BirdFacade bird, InputPanel inputPanel, StateMachine stateMachine)
		{
			_bird = bird;
			_inputPanel = inputPanel;

			_state = stateMachine.ResolveState<InGameState>();
			_state.OnEntered.Subscribe(_ => Enable()).AddTo(_disposables);
			_state.OnExited.Subscribe(_ => Disable()).AddTo(_disposables);
		}

		public void Initialize()
		{
			_inputPanel.Clicked
				.Subscribe(_ => FlapIfEnable())
				.AddTo(_disposables);
			SetIsEnable(false);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		public void Enable() => SetIsEnable(true);

		public void Disable() => SetIsEnable(false);

		private void SetIsEnable(bool isEnable)
		{
			_isEnable = isEnable;
			_inputPanel.IsEnable(isEnable);
		}

		public void FlapIfEnable()
		{
			if (_isEnable)
				_bird.Flap();
		}
	}
}
