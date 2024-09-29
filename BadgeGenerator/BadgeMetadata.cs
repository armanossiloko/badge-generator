namespace BadgeGenerator;

public struct BadgeMetadata
{
	public BadgeMetadata()
	{
		Height = 20;
		Padding = 10;
	}

	/// <summary>
	/// Determines the height of the auto-generated image.
	/// </summary>
	public int Height { get; set; }

	/// <summary>
	/// Determines the padding of the content of the auto-generated image.
	/// </summary>
	public int Padding { get; set; }

	public static BadgeMetadata Default => new()
	{
		Height = 20,
		Padding = 10,
	};

}