using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    // Паттерн State — пример конкретного состояния
    public class ErrorState : IDocumentState
    {
        public void Print(Document document) => Console.WriteLine("[FSM: Error] Printing is impossible due to an error. First, reset the document (Reset).");
    
        public void AddToQueue(Document document) => Console.WriteLine("[FSM: Error] You can't add it to the queue due to an error.First, reset the document.");

        public void CompletePrinting(Document document) => Console.WriteLine("[FSM: Error] The error has not been fixed.");

        public void FailPrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[FSM: Error] The document is already in error condition.");
            Console.ResetColor();
        }

        public void Reset(Document document)
        {
            document.SetState(new NewState());

            Console.WriteLine("[FSM: Error -> New] The document has been reset and is ready to be printed again..");
            document.Mediator?.Notify(document, "AddToQueue", document);
        }
    }
}
