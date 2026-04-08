using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class PrintSystemMediator : IMediator
    {
        // Посредник знает всех конкретных коллег
        private readonly Printer _printer;
        private readonly PrintQueue _queue;
        private readonly Logger _logger;
        private readonly Dispatcher _dispatcher;
        public PrintSystemMediator(Printer printer, PrintQueue queue, Logger logger, Dispatcher dispatcher)
        {
            _printer = printer;
            _queue = queue;
            _logger = logger;
            _dispatcher = dispatcher;

            // Посредник подписывает коллег на себя
            _printer.SetMediator(this);
            _queue.SetMediator(this);
            _logger.SetMediator(this);
            _dispatcher.SetMediator(this);
        }
        // МЕТОД, КОТОРЫЙ РЕАЛИЗУЕТ ВЕСЬ АЛГОРИТМ ВЗАИМОДЕЙСТВИЯ
        public void Notify(Colleague sender, string ev, Document document = null)
        {
            switch (ev)
            {
                // Событие от Документа (через State): "Хочу в очередь"
                case "AddToQueue":
                    if (document != null)
                    {
                        _queue.EnqueueItem(document);
                    }
                    break;

                // Событие от Очереди: "Документ добавлен"
                case "Enqueued":
                    if (document != null)
                    {
                        _logger.WriteMessage($"The document '{document.Title}' has been placed in the queue.");
                    }
                    break;
                // Событие от Документа (через State): "Хочу печататься"
                case "RequestPrint":
                    if (document != null)
                    {
                        document.SetState(new PrintingState()); // Меняем состояние(FSM)
                        _logger.WriteMessage($"The document '{document.Title}' began to be printed.");
                        // Посредник дает команду принтеру
                        _printer.StartPrint(document);
                    }
                        
                    break;

                // Событие от Диспетчера: "Печатай всю очередь"
                case "ProcessQueue":
                    if (_queue.IsEmpty)
                    {
                        _logger.WriteMessage("The queue is empty.");
                        return;
                    }

                    var nextDoc = _queue.DequeueItem();
                    if (nextDoc != null)
                    {
                        nextDoc.SetMediator(this); // Важно: документ тоже коллега, даем ему посредника
                        nextDoc.Print(); // Запускаем цепочку State -> Mediator
                    }
                        
                    break;
                // Событие от Принтера: "Успех"
                case "PrintSuccess":
                    if (document != null)
                    {
                        document.CompletePrinting(); // Посредник дергает State документа
                        _logger.WriteMessage($"Successfully printed '{document.Title}'.");
                    }

                    break;
                // Событие от Принтера: "Ошибка"
                case "PrintFailed":
                    if (document != null)
                    {
                        document.FailPrinting(); // Посредник дергает State документа            
                        _logger.WriteMessage($"Printing error '{document.Title}'.");
                    }
                    break;
            }
        }
    }
}
