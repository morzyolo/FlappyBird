using System;

namespace Core.StateMachines.Game.States
{
	public abstract class State
	{
		public event Action OnEntered;
		public event Action OnExited;

		protected StateMachine StateMachine;

		public void SetStateMachine(StateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public void Enter()
		{
			OnEntered?.Invoke();
		}

		public void Exit()
		{
			OnExited?.Invoke();
		}
	}
}
