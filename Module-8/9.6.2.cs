using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program962
{


    static void Main(string[] args)
    {
        ConsoleReader consoleReader = new ConsoleReader();
        consoleReader.EntireCommandEvent += Sorter;
        consoleReader.ReadFromConsole();
    }

    static void Sorter(int number)
    {
        List<string> sortedNames;
        List<string> names = new List<string>();
        names.Add("Брежнев");
        names.Add("Сталин");
        names.Add("Берия");
        names.Add("Ежов");
        names.Add("Хрущёв");
        if(number == 1)
        {
            sortedNames = names.OrderBy(q => q).ToList();
        }
        else
        {
            sortedNames = names.OrderByDescending(q => q).ToList();
        }
        foreach(string item in sortedNames)
        {
            Console.WriteLine(item);
        }
    }
    
    class ConsoleReader
    {
        public delegate void EntireCommandDelegate(int num);
        public event EntireCommandDelegate EntireCommandEvent;

        public void ReadFromConsole()
        {
            Console.WriteLine("Введиет 1 или 2");
            Console.WriteLine("1: А-Я");
            Console.WriteLine("2: Я-А");
            int number = 0;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("1 или 2");
            }
            if (number != 1 && number != 2)
            {
                throw new FormatException();
            }
            NumberEvent(number);
        }

        protected virtual void NumberEvent(int number)
        {
            EntireCommandEvent?.Invoke(number);
        }
    }
}
