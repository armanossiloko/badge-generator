namespace BadgeGenerator;

public class BadgeSection
{
	/// <summary>
	/// Text (a <see cref="string"/>) or image URL (an <see cref="Uri"/>).
	/// </summary>
	public required BadgeContent Content { get; set; }

	/// <summary>
	/// Determines the size of the icon of this badge section.
	/// </summary>
	/// <remarks>
	/// Should be set only when when <see cref="Content"/> is initialized from an <see cref="Uri"/>.
	/// </remarks>
	public int? IconSize { get; set; } = null;

	/// <summary>
	/// Foreground color of the badge section (text), defaults to #fff (white).
	/// </summary>
	public string ForegroundColor { get; set; } = "#fff";

	/// <summary>
	/// Background color of the badge section, defaults to #555 (dark grey).
	/// </summary>
	public string BackgroundColor { get; set; } = "#555";

}
