using UnityEngine;

public class MenuObjectsMover : ObjectSinusMover
{
	public MenuObjectsMover(
		RectTransform container,
		SinusMovingObjectsConfig config,
		Updater updater)
		: base(container, config, updater)
	{
		StartMoveObjects();
	}
}
