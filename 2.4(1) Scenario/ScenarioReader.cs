using System.Linq;
using System.IO;

namespace _2._4_1__Scenario
{
    class ScenarioReader
    {
        private string _directory;
        private DirectoryInfo _directoryInfo;

        private FileInfo[] _lastFileInfos;
        private int _currentFileIndex;

        public ScenarioReader(string directory)
        {
            _directory = directory;
            _directoryInfo = new DirectoryInfo(_directory);
            _lastFileInfos = GetFileInfos();
        }

        public string[] ReadNext()
        {
            if (!CanReadDirectory())
                return null;

            if (WereFilesChanged())
            {
                _lastFileInfos = GetFileInfos();
                _currentFileIndex = 0;
            }

            string[] result = File.ReadAllLines(_lastFileInfos[_currentFileIndex].FullName);

            _currentFileIndex++;
            if (_currentFileIndex >= _lastFileInfos.Length)
                _currentFileIndex = 0;

            return result;
        }

        public bool CanReadDirectory() => GetFileInfos().Length != 0;

        private bool WereFilesChanged()
        {
            FileInfo[] newFilesInfos = GetFileInfos();

            if (_lastFileInfos.Length != newFilesInfos.Length)
                return true;

            for (int i = 0; i < newFilesInfos.Length; i++)
            {
                if (_lastFileInfos[i].Name != newFilesInfos[i].Name)
                    return true;
            }

            return false;
        }

        private FileInfo[] GetFileInfos() => _directoryInfo.GetFiles().Where(file => file.Name.Any(symbol => char.IsDigit(symbol))).ToArray();
    }
}
