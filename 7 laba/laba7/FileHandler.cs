using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath = "logs.txt") : base(strategy)
        {
            _filePath = filePath;
        }

        protected override string FormatMessage(string eventType, MetricData data)
        {
            string message = $"{eventType}: {data.MetricName} = {data.Value} (threshold: {data.Threshold})";
            return _formatStrategy.Format(message, data.Timestamp);
        }

        protected override void SendMessage(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[FileHandler] Written to a file '{_filePath}'");
        }
    }
}
