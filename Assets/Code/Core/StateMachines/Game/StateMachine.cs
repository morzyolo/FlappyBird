using System;
using System.Collections.Generic;
using Core.StateMachines.Game.States;
using Zenject;

namespace Core.StateMachines.Game
{
	public class StateMachine : IInitializable
	{
		private readonly Dictionary<Type, State> _states;

		private State _currentState;

		public StateMachine(
			StartGameState startState,
			InGameState inState,
			EndGameState endState)
		{
			_states = new()
			{
				{ typeof(StartGameState), startState },
				{ typeof(InGameState), inState },
				{ typeof(EndGameState), endState }
			};

			foreach (var state in _states.Values)
				state.SetStateMachine(this);
		}

		public void Initialize()
		{
			_currentState = ResolveState<StartGameState>();
			_currentState.Enter();
		}

		public S ResolveState<S>()
			where S : State
		{
			if (_states.TryGetValue(typeof(S), out var state))
				return (S)state;

			throw new KeyNotFoundException("State not found");
		}

		public void ChangeState(State currentState, State nextState)
		{
			if (!ReferenceEquals(_currentState, currentState))
				return;

			_currentState.Exit();
			_currentState = nextState;
			_currentState.Enter();
		}
	}
}
