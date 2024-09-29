namespace BadgeGenerator;

public static class BadgeCreator
{
	/// <inheritdoc cref="CreateBadgeSvg(List{BadgeSection}, BadgeMetadata)"/>
	public static string CreateBadgeSvg(List<BadgeSection> badgeSections)
	{
		return CreateBadgeSvg(badgeSections, BadgeMetadata.Default);
	}

	/// <summary>
	/// Creates an SVG badge based on provided configuration.
	/// </summary>
	/// <param name="badgeSections">A list of sections with the content and colors of each section.</param>
	/// <param name="metadata">Metadata for the expected auto-generated badge.</param>
	/// <returns>The auto-generated badge, in SVG format.</returns>
	public static string CreateBadgeSvg(List<BadgeSection> badgeSections, BadgeMetadata metadata)
	{
		int charWidth = 7;
		int totalWidth = 0;

		List<string> columns = [];
		int xOffset = 0;

		foreach (var part in badgeSections)
		{
			var iconSize = part.IconSize ?? 12;

			int width = part.Content.IsUrl ? iconSize + metadata.Padding : part.Content.Length * charWidth + metadata.Padding;
			totalWidth += width;

			string content;

			// IsUrl determines whether to try to render an icon or not.
			if (part.Content.IsUrl)
			{
				content = $"""

                            <rect x='{xOffset}' width='{width}' height='{metadata.Height}' fill='{part.BackgroundColor}'/>
                            <image x='{xOffset + metadata.Padding / 2}' y='{(metadata.Height - iconSize) / 2}' width='{iconSize}' height='{iconSize}'
                                href='{part.Content}' preserveAspectRatio='xMidYMid meet'/>

                    """;
			}
			else
			{
				content = $"""

                            <rect x='{xOffset}' width='{width}' height='{metadata.Height}' fill='{part.BackgroundColor}'/>
                            <text x='{xOffset + (width / 2)}' y='15' fill='{part.ForegroundColor}' font-family='Verdana' font-size='11' text-anchor='middle'>{part.Content}</text>

                    """;
			}

			columns.Add(content);
			xOffset += width;
		}

		return $"""
            <svg xmlns='http://www.w3.org/2000/svg' width='{totalWidth}' height='{metadata.Height}'>
                <clipPath id='roundedCorners'>
                    <rect width='100%' height='100%' rx='3' opacity='1' />
                </clipPath>
                <g clip-path='url(#roundedCorners)'>
                    {string.Join("", columns)}
                </g>
            </svg>
            """;
	}

}
