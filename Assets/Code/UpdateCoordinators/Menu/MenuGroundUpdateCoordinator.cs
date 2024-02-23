using System;
using System.Collections.Generic;
using Configs.Motion;
using Core;
using HeightDeterminers;
using MovingObjects;
using ObjectMovers;
using Resetters;
using UnityEngine;
using Zenject;

namespace UpdateCoordinators.Menu
{
	public sealed class MenuGroundUpdateCoordinator : IInitializable, IDisposable
	{
		private readonly Updater _updater;
		private readonly Resetter<Ground> _resetter;
		private readonly HorizontalMover<Ground> _mover;

		public MenuGroundUpdateCoordinator(
			List<Ground> grounds,
			Updater updater,
			HorizontalMotionConfig motionConfig)
		{
			_updater = updater;
			ConstHeightDeterminer heightDeterminer = new(motionConfig.MaxHeight);
			_resetter = new(grounds, motionConfig, heightDeterminer);
			_mover = new(heightDeterminer, grounds, motionConfig);
		}

		public void Initialize()
		{
			_resetter.Reset();
			_updater.AddListener(_mover);
		}

		public void Dispose()
		{
			_updater.RemoveListener(_mover);
		}
	}
}
