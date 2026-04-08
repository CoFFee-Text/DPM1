using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    // КОНКРЕТНЫЙ КОЛЛЕГА: Диспетчер (UI)
    public class Dispatcher : Colleague
    {
        public void CommandProcessQueue()
        {
            // Диспетчер дает команду посреднику начать обработку очереди
            Mediator.Notify(this, "ProcessQueue");
        }
    }
}
