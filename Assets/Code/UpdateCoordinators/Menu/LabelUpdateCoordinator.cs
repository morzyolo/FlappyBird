using System;
using Configs.Motion;
using Core;
using ObjectMovers;
using UnityEngine;
using Zenject;

namespace UpdateCoordinators.Menu
{
	public sealed class LabelUpdateCoordinator : IInitializable, IDisposable
	{
		private readonly Updater _updater;
		private readonly YSinusMover _mover;

		public LabelUpdateCoordinator(
			Transform transform,
			Updater updater,
			SinusMotionConfig config)
		{
			_updater = updater;
			_mover = new(transform, config);
		}

		public void Initialize()
		{
			_updater.AddListener(_mover);
		}

		public void Dispose()
		{
			_updater.RemoveListener(_mover);
		}
	}
}
