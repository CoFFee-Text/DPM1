using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_4
{
    public sealed class PrototypeRegistry
    {
        private static readonly Lazy<PrototypeRegistry> _instance = new Lazy<PrototypeRegistry>(() => new PrototypeRegistry());
        private Dictionary<string, Computer> _registry;
        public static PrototypeRegistry Instance => _instance.Value;

        private PrototypeRegistry()
        {
            _registry = new Dictionary<string, Computer>();

            _registry["Office"] = new OfficeComputerFactory().CreateComputer();
            _registry["Gaming"] = new GamingComputerFactory().CreateComputer();
            _registry["Home"] = new HomeComputerFactory().CreateComputer();
        }

        public Computer GetPrototype(string key)
        {
            if (!_registry.ContainsKey(key))
            {
                throw new ArgumentException($"Prototype not found");
            }

            return _registry[key].DeepCopy();
        }
    }
}
