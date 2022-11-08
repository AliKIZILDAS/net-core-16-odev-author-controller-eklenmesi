using System;

namespace WebApi.SErvices
{
    public class DbLogger :ILoggerService

    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] -"+message);
        }
        
        
    }
}