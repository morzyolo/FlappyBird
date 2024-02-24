using UI.Elements;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
	public class UIElementsInstaller : MonoInstaller
	{
		[SerializeField] private InputPanel _inputPanel;

		public override void InstallBindings()
		{
			BindInputPanel();
		}

		private void BindInputPanel()
		{
			Container
				.Bind<InputPanel>()
				.FromInstance(_inputPanel);
		}
	}
}
