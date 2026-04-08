using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class PrintingState : IDocumentState
    {
        public void Print(Document document)
        {
            Console.WriteLine($"[FSM: Printing] The document '{document.Title}' is already being printed.");
        }

        public void AddToQueue(Document document)
        {
            Console.WriteLine($"[FSM: Printing] The document '{document.Title}' is already being printed. Can't be added to the queue.");
        }
        public void CompletePrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[FSM: Printing] Document {document.Title} finished printing.");
            Console.ResetColor();
            document.SetState(new DoneState());
        }
        public void FailPrinting(Document document)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[FSM: Printing] Error when printing a document '{document.Title}'.");
            Console.ResetColor();
            document.SetState(new ErrorState());
        }
        public void Reset(Document document)
        {
            Console.WriteLine($"[FSM: Printing] Document {document.Title} cannot be reset. This document is being printed.");
        }
    }
}
