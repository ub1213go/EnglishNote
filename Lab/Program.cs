using Encrypt;
using EnglishNoteService;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;

namespace Lab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var x = new Test();
            foreach (var prop in x.GetType().GetProperties())
            {
                Console.WriteLine(prop.Name);
            }

        }

        public class Test
        {
            public int t;
            public int T { get; set; }
        }
    }   
}