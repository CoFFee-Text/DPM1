using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    // Паттерн State — интерфейс состояния
    public interface IDocumentState
    {
        void Print(Document document);
        void AddToQueue(Document document);
        void CompletePrinting(Document document);
        void FailPrinting(Document document);
        void Reset(Document document);
    }
    public class Document : Colleague
    {
        public string Title { get; set; }

        public IDocumentState State { get; set; }

        public Document(string title)
        {
            Title = title;
            State = new NewState(); // Начальное состояние
        }
        // Метод для смены состояния
        public void SetState(IDocumentState state) => State = state;

        // Делегирование поведения текущему состоянию
        public void Print() => State.Print(this);
        public void AddToQueue() => State.AddToQueue(this);
        public void CompletePrinting() => State.CompletePrinting(this);
        public void FailPrinting() => State.FailPrinting(this);
        public void Reset() => State.Reset(this);
    }
}
