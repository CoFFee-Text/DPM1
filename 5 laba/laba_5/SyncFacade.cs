using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_5
{
    public class SyncFacade
    {
        private IFileSystem _sourceFS;
        private IFileSystem _targetFS;
        public SyncFacade(IFileSystem source, IFileSystem target)
        {
            _sourceFS = source;
            _targetFS = target;
        }

        public void SyncFolder(string sourcePath, string targetPath)
        {
            var items = _sourceFS.ListItems(sourcePath);
            foreach (var item in items)
            {
                string sourceItemPath = $"{sourcePath}/{item}";
                string targetItemPath = $"{targetPath}/{item}";

                byte[] data = _sourceFS.ReadFile(sourceItemPath);

                _targetFS.WriteFile(targetItemPath, data);
                Console.WriteLine("Synchronization is completed");
            }            
        }
        public void Backup(string sourcePath, string backupPath)
        {
            var items = _sourceFS.ListItems(sourcePath);

            try
            {
                foreach (var item in items)
                {
                    string sourceItemPath = $"{sourcePath}/{item}";
                    string backupItemPath = $"{backupPath}/{item}";

                    byte[] sourceData = _sourceFS.ReadFile(sourceItemPath);
                    byte[] backupData = _targetFS.ReadFile(backupItemPath);

                    _targetFS.WriteFile(backupItemPath, sourceData);
                    Console.WriteLine("Backup is completed");
                }
            }
            catch
            {
                Console.WriteLine("Backup error");
            }
        }
    }
}