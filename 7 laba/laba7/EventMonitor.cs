using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public delegate void MetricEventHandler(MetricEventArgs e);
    /// <summary>
    /// Субъект (Subject). Вместо интерфейса ISubject и методов Attach/Detach
    /// использует стандартное событие .NET.
    /// </summary>
    public class EventMonitor
    {

        // Событие (Event) — это ключевой элемент паттерна Observer в C#
        public event MetricEventHandler? OnMetricExceeded;
        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"[Monitor]: Checking {metricName} ({value} vs {threshold})");
            if (value > threshold)
            {
                //ЗДЕСЬ ВАМ НУЖНО СОЗДАТЬ ДАННЫЕ МЕТРИКИ (eventData)
                // Вместо цикла foreach в методе Notify, мы просто вызываем событие.
                // ?.Invoke проверяет, есть ли подписчики.
                var eventData = new MetricData(metricName, value, threshold, DateTime.Now);
                OnMetricExceeded?.Invoke(new MetricEventArgs(eventType: metricName + "_Exceeded", data: eventData));
            }
        }
    }
}