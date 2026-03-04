using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    public class Computer
    {
        private string _cpu;
        private int _ram;
        private string _gpu;
        public string CPU
        {
            get { return _cpu; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("CPU can not be empty");
                }
                _cpu = value;
            }
        }
        public int RAM
        {
            get { return _ram; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("RAM can not be 0 or negative");
                }
                _ram = value;
            }
        }
        public string GPU
        {
            get { return _gpu; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("GPU can not be empty");
                }
                _gpu = value;
            }
        }
        public List<string> AdditionalComponents { get; set; }

        public Computer()
        {
            AdditionalComponents = new List<string>();
        }

        // for builder
        public void Display()
        {
            Console.WriteLine($"This computer has:\nCPU: {CPU}");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine($"GPU: {GPU}");
            Console.WriteLine("AdditionalComponents: ");
            if (AdditionalComponents.Count == 0)
            {
                Console.Write("missing");
            }
            else
            {
                for (int i = 0; i < AdditionalComponents.Count; i++)
                {
                    Console.WriteLine(AdditionalComponents[i]);
                }
            }
            Console.WriteLine("\n");
        }


        // for prototype
        public Computer ShallowCopy()
        {
            return (Computer)MemberwiseClone();
        }
        public Computer DeepCopy()
        {
            Computer otherComp = (Computer)MemberwiseClone();
            otherComp.AdditionalComponents = new List<string>(this.AdditionalComponents);
            return otherComp;
        }
    }
}
