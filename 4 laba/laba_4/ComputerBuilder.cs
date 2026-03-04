using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    public interface IComputerFactory
    {
        Computer CreateComputer();
    }
    public class ComputerBuilder
    {
        private Computer computer;
        public ComputerBuilder()
        {
            computer = new Computer();
        }

        public ComputerBuilder WithCPU(string cpu)
        {
            computer.CPU = cpu;
            return this;
        }
        public ComputerBuilder WithRAM(int ram)
        {
            computer.RAM = ram;
            return this;
        }
        public ComputerBuilder WithGPU(string gpu)
        {
            computer.GPU = gpu;
            return this;
        }
        public ComputerBuilder WithComponent(string component) // add to list
        {
            computer.AdditionalComponents.Add(component);
            return this;
        }
        public Computer Build()
        {
            return computer;
        }
    }
    public class OfficeComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Celeron G1830 2800MHz")
                .WithRAM(4)
                .WithGPU("Integrated graphics Intel UHD")
                .WithComponent("Monitor")
                .WithComponent("Keyboard")
                .WithComponent("Wire Mouse")
                .Build();
        }
    }

    public class GamingComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("Intel Core i7-7700HQ")
                .WithRAM(16)
                .WithGPU("NVIDIA GeForce RTX 1050")
                .Build();
        }
    }

    public class HomeComputerFactory : IComputerFactory
    {
        public Computer CreateComputer()
        {
            return new ComputerBuilder()
                .WithCPU("AMD Ryzen 5 4500U")
                .WithRAM(16)
                .WithGPU("Radeon Graphics")
                .WithComponent("Wire Mouse")
                .WithComponent("Wireless Keyboard")
                .Build();
        }
    }
}
