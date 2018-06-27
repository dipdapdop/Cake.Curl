using Cake.Core;
using Cake.Core.IO;

namespace Cake.Curl
{
    internal static class ArgumentsExtensions
    {
        internal static void AppendSettings(
            this ProcessArgumentBuilder arguments,
            CurlSettings settings)
        {
            if (settings.Verbose)
            {
                arguments.Append("--verbose");
            }

            if (settings.ProgressBar)
            {
                arguments.Append("--progress-bar");
            }

            if (settings.Username != null)
            {
                arguments.AppendSwitchQuoted(
                    "--user",
                    $"{settings.Username}:{settings.Password}");
            }

            if (settings.Insecure)
            {
                arguments.Append("--insecure");
            }

            if (settings.CaCertFile != null)
            {
                arguments.AppendSwitchQuoted(
                    "--cacert",
                    $"{settings.CaCertFile}");
            }

            if (settings.Headers != null)
            {
                foreach (var item in settings.Headers)
                {
                    arguments.AppendSwitchQuoted(
                        "--header",
                        $"{item.Key}:{item.Value}");
                }
            }

            if (settings.RequestCommand != null)
            {
                arguments.AppendSwitchQuoted(
                    "--request",
                    settings.RequestCommand.ToUpperInvariant());
            }

            if (settings.FollowRedirects)
            {
                arguments.Append("--location");
            }
        }
    }
}
