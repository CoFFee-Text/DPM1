using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class NewState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: New] The document '{document.Title}' sent for printing.");
            // Коллега (Document) через свое состояние дает команду посреднику
            document.Mediator?.Notify(document, "RequestPrint", document);
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: New] The document '{document.Title}' added to queue.");
            document.Mediator?.Notify(document, "AddToQueue", document);
        }
        public void CompletePrinting(Document document)
        {
            Console.WriteLine($"[FSM: New] Document {document.Title} is not being printed yet.");
        }
        public void FailPrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FSM: New] Document {document.Title} is not being printed yet. It is impossible to get an error.");
            Console.ResetColor();
        }
        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: New] Document {document.Title} is still in the New state.");
        }
    }
}
