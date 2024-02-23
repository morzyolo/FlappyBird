using Core.StateMachines.Game;
using Core.StateMachines.Game.States;
using Zenject;

namespace Assets.Scripts.Installers.Game
{
	public class StateMachineInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindState<StartGameState>();
			BindState<InGameState>();
			BindState<EndGameState>();
			BindStatemachine();
		}

		private void BindState<S>() where S : State
		{
			Container
				.BindInterfacesAndSelfTo<S>()
				.AsSingle();
		}

		private void BindStatemachine()
		{
			Container
				.BindInterfacesAndSelfTo<StateMachine>()
				.AsSingle();
		}
	}
}
