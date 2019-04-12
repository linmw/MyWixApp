using System;
using System.Drawing;
using System.Security.Cryptography;
using Dependency;

namespace MyWixApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dependency = new MyDependency();
            dependency.Name = "Hello World";
            Console.WriteLine(dependency.Name);
            Console.ReadLine();
        }
    }
}
