using laba_4;
using static laba_4.ComputerBuilder;


Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("-- Builder --");
Console.ResetColor();

Console.WriteLine("Office computer");
IComputerFactory officeFactory = new OfficeComputerFactory();
Computer officePC = officeFactory.CreateComputer();
officePC.Display();

Console.WriteLine("Gaming computer");
IComputerFactory gamingFactory = new GamingComputerFactory();
Computer gamingPC = gamingFactory.CreateComputer();
gamingPC.Display();

Console.WriteLine("Home computer");
IComputerFactory homeFactory = new HomeComputerFactory();
Computer homePC = homeFactory.CreateComputer();
homePC.Display();


Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("-- Prototype --");
Console.ResetColor();

Console.WriteLine("Shallow Copy");
Console.WriteLine("Before Shallow copy Home computer configuration");

IComputerFactory homeFactorySC = new HomeComputerFactory();
Computer homePC_SC = homeFactorySC.CreateComputer();
Computer shallowCopyHomePC = homePC_SC.ShallowCopy();
Console.WriteLine("Home PC");
homePC_SC.Display();
Console.WriteLine("Shallow copy Home PC");
shallowCopyHomePC.Display();

shallowCopyHomePC.AdditionalComponents.Add("Second monitor");

Console.WriteLine("After Shallow copy Home computer configuration (with new additional)");
Console.WriteLine("Home PC");
homePC_SC.Display();
Console.WriteLine("Shallow copy Home PC");
shallowCopyHomePC.Display();

Console.WriteLine("Deep Copy");
Console.WriteLine("Before Deep copy Home computer configuration");

IComputerFactory homeFactoryDC = new HomeComputerFactory();
Computer homePC_DC = homeFactoryDC.CreateComputer();
Computer deepCopyHomePC = homePC_DC.DeepCopy();
Console.WriteLine("Home PC");
homePC_DC.Display();
Console.WriteLine("Deep copy Home PC");
deepCopyHomePC.Display();

deepCopyHomePC.AdditionalComponents.Add("Second monitor");

Console.WriteLine("After Deep copy Home computer configuration (with new additional)");
Console.WriteLine("Home PC");
homePC_DC.Display();
Console.WriteLine("Deep copy Home PC");
deepCopyHomePC.Display();



Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("-- Singleton --");
Console.ResetColor();

Console.WriteLine("Gaming computer");
IComputerFactory gamingFactoryS = new GamingComputerFactory();
Computer gamingPC_S = gamingFactoryS.CreateComputer();
gamingPC_S.Display();

PrototypeRegistry registry = PrototypeRegistry.Instance;

Computer newGamingPC_S = registry.GetPrototype("Gaming");
Console.WriteLine("'Gaming' in registry");
registry.GetPrototype("Gaming").Display();

Console.WriteLine("Modified 'Gaming' clone prototype");
newGamingPC_S.RAM = 8;
newGamingPC_S.AdditionalComponents.Add("Keyboard");
newGamingPC_S.Display();

Console.WriteLine("'Gaming' in registry");
Computer gamingCheck = registry.GetPrototype("Gaming");
gamingCheck.Display();