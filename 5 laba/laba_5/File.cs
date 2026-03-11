using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    public class ClassFile : FileSystemItem // вот это листик
    {
        private int FileSize;

        public ClassFile(string name, int fileSize) : base(name)
        {
            if (fileSize < 0)
            {
                throw new ArgumentException("File size cannot be negative");
            }                
            FileSize = fileSize;
        }
        public override long GetSize()
        {
            return FileSize;
        }

        public override void Add(FileSystemItem file)
        {
            throw new InvalidOperationException();
        }

        public override FileSystemItem? GetChild(int index)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(FileSystemItem item)
        {
            throw new InvalidOperationException();
        }
    }
}
