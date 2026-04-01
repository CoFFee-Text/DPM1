using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy; //текущая стратегия
        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }
        //Метод установки стратегии
        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        // Данный метод определит последовательность вызовов
        //Обратите внимание на сигнатуру
        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data); //форматируем по стратегии
            SendMessage(message); //отправляем уведомление
            LogResult(); //логируем результат (опционально)
        }
        protected abstract string FormatMessage(string eventType, MetricData data);
        protected abstract void SendMessage(string message);
        protected abstract void LogResult();
    }
}
