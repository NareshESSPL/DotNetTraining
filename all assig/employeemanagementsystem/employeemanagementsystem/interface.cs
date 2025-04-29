using System;

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

class Programz
{
    static void Main()
    {
        ILogger logger = new ConsoleLogger();
        logger.Log("This is a log message.");
    }
}
