namespace HeightDeterminers
{
	public class ConstHeightDeterminer : IHeightDeterminer
	{
		public float Height { get; }

		public ConstHeightDeterminer(float height)
		{
			Height = height;
		}
	}
}
