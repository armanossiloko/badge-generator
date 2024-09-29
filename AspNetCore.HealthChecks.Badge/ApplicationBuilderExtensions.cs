using BadgeGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AspNetCore.HealthChecks.Badge;

public static class ApplicationBuilderExtensions
{
	/// <inheritdoc cref="HealthCheckApplicationBuilderExtensions.UseHealthChecks(IApplicationBuilder, PathString)"/>>
	public static IApplicationBuilder UseHealthBadge(
		this IApplicationBuilder app,
		PathString path
		)
	{
		return app
			.UseHealthChecks(path, new HealthCheckOptions
			{
				ResponseWriter = async (context, report) =>
				{
					context.Response.ContentType = "image/svg+xml";

					BadgeSection badgeSection = new()
					{
						BackgroundColor = "#555",
						Content = "Status",
						ForegroundColor = "#fff"
					};
					BadgeSection statusSection = new()
					{
						Content = report.Status.ToString(),
						ForegroundColor = "#fff"
					};
					switch (report.Status)
					{
						case HealthStatus.Unhealthy:
							statusSection.BackgroundColor = "rgb(139, 0, 0)";
							break;
						case HealthStatus.Degraded:
							statusSection.BackgroundColor = "rgb(222, 162, 9)";
							statusSection.ForegroundColor = "#000";
							break;
						case HealthStatus.Healthy:
							statusSection.BackgroundColor = "rgb(11, 97, 42)";
							break;
						default:
							break;
					}

					string svg = BadgeCreator.CreateBadgeSvg([badgeSection, statusSection]);
					await context.Response.WriteAsync(svg);
				}
			});
	}

}
