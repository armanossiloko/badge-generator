<p align="center">
  <a title="NuGet download" target="_blank" href="https://www.nuget.org/packages/BadgeGenerator"><img src="https://img.shields.io/nuget/dt/BadgeGenerator"></a>
  <a title="NuGet download" target="_blank" href="https://www.nuget.org/packages/BadgeGenerator"><img alt="NuGet" src="https://img.shields.io/nuget/v/BadgeGenerator"></a>
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/armanossiloko/badge-generator">
  <img alt="GitHub repo size" src="https://img.shields.io/github/repo-size/armanossiloko/badge-generator">
  <a title="MIT License" target="_blank" href="https://licenses.nuget.org/MIT"><img src="https://img.shields.io/github/license/armanossiloko/badge-generator"></a>
</p>

# Badge Generator Library

This is a simple .NET library that can generate SVG badges dynamically. The badges can contain text as well as icons (through image URLs) and are customizable in terms of size, padding and colors.

## Installation

To include this library in your project, you can install one of the two "variants":

- The classic `BadgeGenerator` providing raw capabilities for generating badge SVGs:
```bash
dotnet add package BadgeGenerator
```

- Alternatively, you can install the `AspNetCore.HealthChecks.Badge` version which provides a middleware extension that returns a badge containing your application's current health status:
```bash
dotnet add package AspNetCore.HealthChecks.Badge
```

## Usage

### Creating a Badge

To create a badge, you need to define the sections and metadata, and then call the `CreateBadgeSvg` method to generate the SVG.

### Example

Here is an example of how to create a badge with two sections:

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

### Health Checks endpoint

You can install `AspNetCore.HealthChecks.Badge` and register an `UseHealthBadge()` middleware somewhere in your app's pipeline.

```csharp
app.UseHealthBadge("healthz");
```

The result could, when an HTTP request is sent towards `/healthz`, look something like this for various health statuses:

<img alt="Healthy status badge" src="./img/healthy.svg">
<img alt="Degraded status badge" src="./img/degraded.svg">
<img alt="Unhealthy status badge" src="./img/unhealthy.svg">


## Contributing

Got suggestions, found a bug or would like to contribute? If so, feel free to create issues or pull requests.
Please do make sure to:

- Try to write clear and concise commit messages.
- Try to add tests if containing more complex logic.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
