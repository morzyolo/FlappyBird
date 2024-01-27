using UnityEngine;

namespace Configs.Data
{
	[System.Serializable]
	public class BirdAnimationData
	{
		public int FrameDelayMs => _frameDelayMs;
		public Sprite DefaultFrame => _defaultFrame;
		public Sprite[] FlapFrames => _flapFrames;

		[SerializeField] private int _frameDelayMs;
		[SerializeField] private Sprite _defaultFrame;
		[SerializeField] private Sprite[] _flapFrames;
	}
}
