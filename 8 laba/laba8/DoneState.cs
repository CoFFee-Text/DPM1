using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class DoneState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Done] The document '{document.Title}' already printed.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Done] The document '{document.Title}' has already been printed. Can't be added to the queue.");
        }
        public void CompletePrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[FSM: Done] Document {document.Title} has already finished printing.");
            Console.ResetColor();
        }
        public void FailPrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FSM: Done] The document '{document.Title}' has already been printed. It is impossible to get an error.");
            Console.ResetColor();
        }
        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Done] The document '{document.Title}' has already been printed. Document {document.Title} cannot be reset.");
        }
    }
}
