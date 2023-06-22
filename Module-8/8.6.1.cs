

namespace DirectoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileRemover("C:\\Temp\\testfolder");
        }

        public static void FileRemover(string folderPath)
        {
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {

                try
                {
                    if (DateTime.UtcNow.Subtract(dir.LastAccessTimeUtc).Minutes > 1)
                    {
                        dir.Delete(true);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
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
        }
    }
}