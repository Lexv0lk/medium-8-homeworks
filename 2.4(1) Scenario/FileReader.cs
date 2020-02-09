using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace _2._4_1__Scenario
{
    class FileReader : IScenarioReader
    {
        private string _directory;
        private DirectoryInfo _directoryInfo;

        private FileInfo[] _lastFileInfos;
        private int _currentFileIndex;

        public FileReader(string directory)
        {
            _directory = directory;
            _directoryInfo = new DirectoryInfo(_directory);
            _lastFileInfos = GetFileInfos();
        }

        public string[] ReadNext()
        {
            if (CanRead() == false)
                throw new FileNotFoundException();

            string[] result = File.ReadAllLines(_lastFileInfos[_currentFileIndex].FullName);

            _currentFileIndex++;
            if (_currentFileIndex >= _lastFileInfos.Length)
                _currentFileIndex = 0;

            return result;
        }

        public bool CanRead() => GetFileInfos().Length != 0;

        private FileInfo[] GetFileInfos()
        {
            List<FileInfo> result = new List<FileInfo>();

            foreach (var file in _directoryInfo.GetFiles())
                if (file.Name.Any(symbol => char.IsDigit(symbol)))
                    result.Add(file);

            return result.ToArray();
        }
    }
}
