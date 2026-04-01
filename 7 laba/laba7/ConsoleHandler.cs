using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }

        protected override string FormatMessage(string eventType, MetricData data)
        {
            string message = $"{eventType}: {data.MetricName} = {data.Value} (threshold: {data.Threshold})";
            return _formatStrategy.Format(message, data.Timestamp);
        }

        protected override void SendMessage(string message)
        {
            Console.WriteLine(message);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[ConsoleHandler] The notification was sent to the console in {DateTime.Now:HH:mm:ss}");
        }
    }
}
