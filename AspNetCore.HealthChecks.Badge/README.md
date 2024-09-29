# AspNetCore.HealthChecks.Badge

This library takes advantage of `Microsoft.Extensions.Diagnostics.HealthChecks` and provides a middleware that returns an image with the current health status of your web application in SVG form.

## Installation

Install the package by adding it through the NuGet Package Manager, or by executing:

```bash
dotnet add package AspNetCore.HealthChecks.Badge
```

## Usage

Using the package is as simple as registering a middleware in your application's pipeline.

```csharp
app.UseHealthBadge("healthz");
```

## Contributing

Read more about this project on the [Github repository](https://github.com/armanossiloko/badge-generator) page.

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.
