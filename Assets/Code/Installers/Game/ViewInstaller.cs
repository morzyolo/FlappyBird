using UI.Views.Game;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
	public class ViewInstaller : MonoInstaller
	{
		[SerializeField] private StartGameView _startView;
		[SerializeField] private EndGameView _endGameView;

		[SerializeField] private ScoreView _scoreView;

		public override void InstallBindings()
		{
			BindView<StartGameView>(_startView);
			BindView<EndGameView>(_endGameView);
			BindView<ScoreView>(_scoreView);
		}

		private void BindView<TView>(MonoBehaviour instance)
		{
			Container
				.BindInterfacesAndSelfTo<TView>()
				.FromInstance(instance)
				.AsSingle();
		}
	}
}
