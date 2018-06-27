using Cake.Core.Tooling;
using System.Collections.Generic;

namespace Cake.Curl
{
    /// <summary>
    /// Contains the settings used by curl.
    /// </summary>
    public class CurlSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to enable verbose output.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to display a simple progress bar
        /// instead of the standard progress meter.
        /// </summary>
        /// <remarks>
        /// By default, curl displays a progress meter during its operations. This meter
        /// contains information such as the amount of transferred data, transfer speed
        /// and the estimated time left. When the <see cref="P:ProgressBar"/> property
        /// is set to <see langword="true"/>, curl displays a single line of <em>#</em>
        /// characters instead. This may be preferable when running the build script
        /// in a terminal where we want to keep the amount of output to a minimum.
        /// </remarks>
        public bool ProgressBar { get; set; }

        /// <summary>
        /// Gets or sets the username to use when authenticating to the remote host.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password to use when authenticating to the remote host.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the header to use when communicating to the remote host.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the command to use in the request.
        /// </summary>
        /// <remarks>
        /// The set of commands that are considered valid for a particular request
        /// depends on the protocol used to talk to the remote service.
        /// For an HTTP request any valid HTTP method—such as <code>PUT</code>, <code>GET</code>,
        /// <code>POST</code> and <code>DELETE</code>—will do. Other protocols might have
        /// their own set of commands; for example, FTP has <code>LIST</code>
        /// while WebDAV supports <code>COPY</code>.
        /// Note that specifying the command using this option will simply set
        /// the word in the request and won't change curl's behavior in any way.
        /// If curl already has a dedicated option to perform a particular operation,
        /// it's almost always better to use that option instead of specifying the command directly,
        /// since that will make sure that curl behaves accordingly.
        /// For example, in order to send an HTTP <code>HEAD</code> request, setting the <code>"HEAD"</code>
        /// command in the request isn't enough. In that case, the dedicated <code>-I --head</code> option
        /// is a far better choice.
        /// </remarks>
        public string RequestCommand { get; set; }

        /// <summary>
        /// Gets or sets a flag telling curl to follow HTTP redirects.
        /// </summary>
        /// <remarks>
        /// If the remote service responds with a 3xx status code and this flag
        /// is set to <see langword="true"/>, curl will redo the request
        /// to the URL found in the <code>Location</code> response header.
        /// Note that if the remote service responded with a <code>301</code> (<em>Moved Permanently</em>),
        /// <code>302</code> (<em>Found</em>) or <code>303</code> (<em>See Other</em>) status code,
        /// curl will redo the request using the <code>GET</code> method, even if the original request
        /// was using another method (like for example <code>PUT</code> or <code>POST</code>).
        /// For all other 3xx status codes, curl will redo the request using the same method
        /// as the one specified in the original request.
        /// </remarks>
        public bool FollowRedirects { get; set; }

        /// <summary>
        /// Passes the --insecure argument to curl
        /// </summary>
        public bool Insecure { get; set; }

        /// <summary>
        /// Path to the CACERT file. (--cacert FILE)
        /// </summary>
        public string CaCertFile { get; set; }
    }
}
