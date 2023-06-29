using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace FinalTask
{
    class FinalTask
    {
        static void Main(string[] args)
        {
            string binFilePath = "D:\\temp\\Students.dat";
            ReadValues(binFilePath);
        }



        [Serializable]
        public class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public static void WriteFile(Student[] studentList) // Принимаем параметр - Student
        {
            var folderPath = "D:\\temp\\Students";

            foreach (var s in studentList)
            {
                var curentPath = folderPath + "\\" + s.Group;
                if (!Directory.Exists(curentPath))
                {
                    Directory.CreateDirectory(curentPath);
                }

                using (StreamWriter writer = new StreamWriter(curentPath + @"\StudentList.txt", true))
                {
                    string row = $"Name:{s.Name}|BirthDay:{s.DateOfBirth}";
                    writer.WriteLineAsync(row);
                }
            }
        }

        static void ReadValues(string binFilePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (var fs = new FileStream(binFilePath, FileMode.Open))
            {
                var studentList = (Student[])formatter.Deserialize(fs);
                Console.WriteLine("Из файла считано:");
            }
        }
    }
}