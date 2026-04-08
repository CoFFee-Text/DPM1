using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    // MEDIATOR: Предоставляет интерфейс для обмена информацией
    public interface IMediator
    {
        // Коллеги вызывают этот метод, чтобы передать событие посреднику
        void Notify(Colleague sender, string ev, Document document = null);
    }
    // COLLEAGUE: Базовый класс для всех коллег.
    // Знает о посреднике и умеет с ним связываться.
    public abstract class Colleague
    {
        public IMediator Mediator;
        // Метод для инъекции посредника
        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
