using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class PrintQueue : Colleague
    {
        private Queue<Document> _queue = new Queue<Document>();

        public bool IsEmpty 
        { 
            get { return _queue.Count == 0; } 
        } 

        public void EnqueueItem(Document document)
        {
            _queue.Enqueue(document);
            Mediator?.Notify(this, "Enqueued", document);
        }

        public Document DequeueItem()
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }
            else
            {
                return null;
            }
        }
    }
}
