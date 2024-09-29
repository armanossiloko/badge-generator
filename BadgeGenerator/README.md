# BadgeGenerator

Provides possibility of programmatically generating SVG badges.

## Installation

```bash
dotnet add package BadgeGenerator
```

## Usage

```csharp
using BadgeGenerator;

List<BadgeSection> badgeSections = new()
{
    new()
    {
        Content = new Uri("https://example.com/healthy.png"),
        IconSize = 12,
        BackgroundColor = "#555"
    },
    new()
    {
        Content = "Status",
        ForegroundColor = "#fff",
        BackgroundColor = "#555"
    },
    new()
    {
        Content = "Healthy",
        ForegroundColor = "#fff",
        BackgroundColor = "rgb(11, 97, 42)"
    }
};

var badgeSvg = BadgeCreator.CreateBadgeSvg(badgeSections, new BadgeMetadata { Height = 20, Padding = 10 });
Console.WriteLine(badgeSvg);
```

This will output the SVG of the badge with three sections: one with a `healthy.png` icon, another with the text "Status" and the third one with text "Healthy". You can customize the badge's size and padding by passing a `BadgeMetadata` object:

```csharp
var metadata = new BadgeMetadata
{
    Height = 28,
    Padding = 12
};
```

## Contributing

Read more about this project on the [Github repository](https://github.com/armanossiloko/badge-generator) page.

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.
