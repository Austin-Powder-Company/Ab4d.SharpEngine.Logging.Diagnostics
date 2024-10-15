using Ab4d.SharpEngine.Common;
using System.Diagnostics;

namespace Ab4d.SharpEngine.Logging.Diagnostics;

public static class TraceWriter
{
    /// <summary>
    /// Writes SharpEngine logs to <see cref="System.Diagnostics.Trace" />.
    /// </summary>
    public static void WriteTo()
    {
        Ab4d.SharpEngine.Utilities.Log.AddLogListener((logLevels, logArea, id, message) =>
        {
            switch (logLevels)
            {
                case LogLevels.None:
                    return;
                default:
                case LogLevels.All:
                    Trace.TraceInformation(message);
                    Trace.TraceWarning(message);
                    Trace.TraceError(message);
                    break;
                case LogLevels.Debug:
                case LogLevels.Info:
                case LogLevels.License:
                    Trace.TraceInformation(message);
                    break;
                case LogLevels.Warn:
                    Trace.TraceWarning(message);
                    break;
                case LogLevels.Error:
                case LogLevels.Fatal:
                    Trace.TraceError(message);
                    break;
            }
        });
    }
}
