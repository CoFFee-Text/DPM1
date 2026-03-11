using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace laba_5
{
    // Target
    public interface IFileSystem
    {
        List<string> ListItems(string path);
        byte[] ReadFile(string path);
        void WriteFile(string path, byte[] data);
        void DeleteItem(string path);
    }
    public class AdapterFileSystem : IFileSystem
    {
        public FileSystemItem Root { get; set; }

        public AdapterFileSystem(FileSystemItem root)
        {
            Root = root;
        }
        private FileSystemItem? FindItem(string path)
        {
            if (string.IsNullOrEmpty(path) || path == Root.Name)
                return Root;
            // just item search            
            return null;
        }
        public List<string> ListItems(string path)
        {
            var item = FindItem(path);
            if (item == null)
            {
                return new List<string>();
            }
            if (item is Folder folder)
            {
                var result = new List<string>();
               
                for (int i = 0; i < 10; i++)
                {
                    var child = folder.GetChild(i);
                    if (child != null)
                        result.Add(child.Name);
                }
                return result;
            }

            return new List<string>();
        }
        public byte[] ReadFile(string path)
        {
            var item = FindItem(path);

            if (item == null)
            {
                return Array.Empty<byte>();
            }

            if (item is ClassFile file)
            {
                return new byte[file.GetSize()];
            }

            return Array.Empty<byte>();
        }
        public void WriteFile(string path,byte[] data)
        {
            Console.WriteLine($"The file is written to the path: {path}.\nFile size is {data.Length}");
        }
        public void DeleteItem(string path)
        {
            var item = FindItem(path);

            if (item == null)
            {
                return;
            }
            string parentPath = "C:/just/path";
            var parent = FindItem(parentPath);

            if (parent is Folder parentFolder)
            {
                parentFolder.Remove(item);
            }
        }
    }
}