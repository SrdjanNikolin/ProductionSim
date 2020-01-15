using System;
using System.IO;

namespace ProductionSimulation.Logger
{
    public class Log
    {
        public void LogAction(DateTime time, string action, string message)
        {
            using (StreamWriter writer = new StreamWriter($"C:\\Users\\Srdjan\\Desktop\\Projects\\ProductionSimulation\\Logs\\{action}.txt", true))
            {
                writer.WriteLine($"[{time.ToString()}] {message}");
            }
        }
    }
}