
using laba_5;

Folder folder1 = new Folder("Photos");

ClassFile file1 = new ClassFile("Photka 1", 1345);
ClassFile file2 = new ClassFile("Risunok", 4096);
ClassFile file3 = new ClassFile("Kak zhit?", 3253);
Folder folder_in_folder = new Folder("Papka v papke");

folder1.Add(file1);
folder1.Add(file2);
folder1.Add(file3);

folder1.Add(folder_in_folder);

Console.WriteLine($"Directory size: {folder1.GetSize()} bytes");