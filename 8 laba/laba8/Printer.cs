using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Printer : Colleague
    {
        public bool SimulateFailure { get; set; } = false;

        public void StartPrint(Document document)
        {

            Console.WriteLine($"[Printer] Physical printing '{document.Title}'...");
        
            if (SimulateFailure)
            {
                SimulateFailure = false;
                //Принтер не меняет состояние документа сам!
                //Он просто сообщает посреднику: "Я сломался при печати вот
               // этого документа"
                Mediator.Notify(this, "PrintFailed", document);
            }
            else
            {
                // Принтер сообщает посреднику: "Я успешно напечатал"
                Mediator.Notify(this, "PrintSuccess", document);
            }
        }
    }
}
