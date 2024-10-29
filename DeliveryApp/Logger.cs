using System;
using System.IO;

class Logger
{
    private readonly string LogFilePath;

    public Logger(string logFilePath)
    {
        LogFilePath = logFilePath;
    }

    public void Log(string message)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи лога: {ex.Message}");
        }
    }
}
