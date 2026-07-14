// TODO: define the 'LogLevel' enum
public enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        // Code staat altijd op index 1, 2 en 3
        string code = "" + logLine[1] + logLine[2] + logLine[3];
    
        switch (code)
        {
            case "TRC": return LogLevel.Trace;
            case "DBG": return LogLevel.Debug;
            case "INF": return LogLevel.Info;
            case "WRN": return LogLevel.Warning;
            case "ERR": return LogLevel.Error;
            case "FTL": return LogLevel.Fatal;
        }
    
        // Geen default → jij kent dat nog niet
        return LogLevel.Unknown;
        }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        string code = "";

        switch (logLevel)
        {
            case LogLevel.Trace:   code = "1"; break;
            case LogLevel.Debug:   code = "2"; break;
            case LogLevel.Warning: code = "5"; break;
            case LogLevel.Info:    code = "4"; break;
            case LogLevel.Error:   code = "6"; break;
            case LogLevel.Fatal:   code = "42"; break;
            case LogLevel.Unknown: code = "0"; break;
        }
    
        return code + ":" + message;
    }
}
