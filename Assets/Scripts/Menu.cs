public class Menu
{
	private readonly string _gameSceneName = "Game";

	private readonly MenuUI _ui;
	private readonly SceneChanger _sceneChanger;

	public Menu(MenuUI ui, SceneChanger sceneChanger)
	{
		_ui = ui;
		_sceneChanger = sceneChanger;

		_ui.Initialize(this);
	}

	public async void StartGame() => await _sceneChanger.ChangeSceneAsync(_gameSceneName);
}
