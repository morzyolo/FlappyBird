using System;

namespace Core.StateMachines.Game.States
{
	public abstract class State
	{
		public event Action OnEntered;
		public event Action OnExited;

		protected readonly StateMachine StateMachine;

		protected State(StateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public abstract void SetNextState();
		public abstract void GoToNext();

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
