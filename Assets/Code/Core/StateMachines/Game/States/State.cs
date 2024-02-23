using UniRx;

namespace Core.StateMachines.Game.States
{
	public abstract class State
	{
		public ReactiveCommand OnEntered { get; } = new();
		public ReactiveCommand OnExited { get; } = new();

		protected StateMachine StateMachine;

		public void SetStateMachine(StateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}

		public void Enter()
		{
			OnEntered.Execute();
		}

		public void Exit()
		{
			OnExited.Execute();
		}
	}
}
