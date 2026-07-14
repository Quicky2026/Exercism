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
        string code = logLevel switch
        {
            LogLevel.Trace   => "1",
            LogLevel.Debug   => "2",
            LogLevel.Info    => "4",
            LogLevel.Warning => "5",
            LogLevel.Error   => "6",
            LogLevel.Fatal   => "42",
            LogLevel.Unknown => "0"
        };
    
        return $"{code}:{message}";
    }
}
