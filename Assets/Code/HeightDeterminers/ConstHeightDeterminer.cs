namespace HeightDeterminers
{
	public class ConstHeightDeterminer : IHeightDeterminer
	{
		public float Height => _height;

		private readonly float _height;

		public ConstHeightDeterminer(float height)
		{
			_height = height;
		}
	}
}
