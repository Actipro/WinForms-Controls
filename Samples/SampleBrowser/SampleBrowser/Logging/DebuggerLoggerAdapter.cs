#if MS_LOGGING

using ActiproSoftware.Logging;
using Microsoft.Extensions.Logging;
using IMSExtensionsLogger = Microsoft.Extensions.Logging.ILogger;
using MSExtensionsLogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace ActiproSoftware.SampleBrowser.Logging;

/// <summary>
/// Defines an adapter of <see cref="DebuggerLogger"/> for use with Microsoft logging.
/// </summary>
internal class DebuggerLoggerAdapter : DebuggerLogger, IMSExtensionsLogger {

	// --------------------------------------------------------------------------------------------------
	// OBJECT
	// --------------------------------------------------------------------------------------------------

	/// <summary>
	/// Initializes an instance of the class.
	/// </summary>
	/// <param name="categoryName">The category name of the logger.</param>
	public DebuggerLoggerAdapter(string categoryName) : base(categoryName) { }

	// --------------------------------------------------------------------------------------------------
	// INTERFACE IMPLEMENTATION
	// --------------------------------------------------------------------------------------------------

	IDisposable IMSExtensionsLogger.BeginScope<TState>(TState state)
		=> BeginScope()!;

	bool IMSExtensionsLogger.IsEnabled(MSExtensionsLogLevel logLevel)
		=> IsEnabled(logLevel.ToActiproLogLevel());

	void IMSExtensionsLogger.Log<TState>(MSExtensionsLogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
		// Quit if not enabled
		if (!IsEnabled(logLevel.ToActiproLogLevel()))
			return;

		// Format the text
		if (formatter is null)
			throw new ArgumentNullException(nameof(formatter));
		string text = formatter(state, exception);

		// Write the log entry
		DebugWriteLine(logLevel.ToActiproLogLevel(), exception, text);
	}

}

#endif
