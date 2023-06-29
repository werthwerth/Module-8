namespace DirectoryManager
{
    class Program2
    {
        static void Main(string[] args)
        {
            string path = "D:\\temp\\testfolder";
            Console.WriteLine(RecursiveSizeCalculator(path));
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
    }
}