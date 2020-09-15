using System.IO;

namespace ReceiverModule
{
    class FileChecker
    {
        public bool CheckWhetherFileExists(string filepath)
        {
            if (File.Exists(filepath))
            {
                return true;
            }
            return false;
        }
    }

}
