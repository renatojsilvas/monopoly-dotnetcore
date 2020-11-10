using System;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldGenerator generator = new HelloWorldGenerator();
            Console.WriteLine(generator.Show("Renato"));
        }
    }
}
