using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CustomEx : Exception
{
    public CustomEx(string message) : base(message)
    {
        // Some code
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<Exception> exceptions = new List<Exception>()
        {
            new CustomEx("Custom Exeption Text"),
            new ArgumentException(),
            new ArgumentNullException(),
            new ArgumentNullException(),
            new DivideByZeroException()
            
        };

        foreach (var exception in exceptions)
        {
            try
            {
                throw exception;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
