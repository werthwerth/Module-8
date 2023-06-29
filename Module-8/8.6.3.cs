using System.Drawing;

namespace DirectoryManager
{
    class Program3
    {
        static void Main(string[] args)
        {
            string path = "D:\\temp\\testfolder";
            long sizeBefore = RecursiveSizeCalculator(path);
            Console.WriteLine("Исходный размер папки: {0} байт", sizeBefore);
            Console.WriteLine("Удалено файлов: {0}", RecursiveFileRemover(path));
            long sizeAfter = RecursiveSizeCalculator(path);
            Console.WriteLine("Освобождено: {0} байт", sizeBefore - sizeAfter);
            Console.WriteLine("Текущий размер папки: {0} байт", sizeAfter);
        }

        public static long RecursiveSizeCalculator(string folderPath)
        {
            long size = 0;
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                size += file.Length;
            }
            if (dirInfo.GetDirectories().Count() > 0)
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    size += RecursiveSizeCalculator(dir.FullName);
                }
            }
            return size;
        }

        public static int RecursiveFileRemover(string folderPath)
        {
            int answer = 0;
            var dirInfo = new DirectoryInfo(folderPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    if (DateTime.UtcNow.Subtract(file.LastAccessTimeUtc).Minutes > 1)
                    {
                        answer++;
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
                    answer += RecursiveFileRemover(dir.FullName);
                }
            }
            if(dirInfo.GetDirectories().Count() == 0 && dirInfo.GetFiles().Count() == 0)
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
            return answer;
        }
    }
}