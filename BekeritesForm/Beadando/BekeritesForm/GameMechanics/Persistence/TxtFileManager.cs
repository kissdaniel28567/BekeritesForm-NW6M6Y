using iText.Kernel.Geom;
using System;
using System.IO;

namespace GameMechanics.Persistence {
    internal class TxtFileManager: IFileManager
    {
        private readonly string _path;
        
        public TxtFileManager(string path)
        {
            _path = path;
        }

        public string Load()
        {
            try
            {
                //if (File.Exists(_path)) {
                //    File.Delete(_path);
                //}
                return File.ReadAllText(_path);
            }
            catch (Exception)
            {
                throw new IOException();
            }
        }
    }
}

