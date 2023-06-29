

namespace DirectoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\temp\\testfolder";
            RecursiveFileRemover(path);
        }

        public static void RecursiveFileRemover(string folderPath)
        {
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    if (DateTime.UtcNow.Subtract(file.LastAccessTimeUtc).Minutes > 1)
                    {
                        file.Delete();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            if (dirInfo.GetDirectories().Count() > 0)
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    RecursiveFileRemover(dir.FullName);
                }
            }
            if (dirInfo.GetDirectories().Count() == 0 && dirInfo.GetFiles().Count() == 0)
            {
                try
                {
                    dirInfo.Delete(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}