using System;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class A
        {
            public A()
            {
                Console.Write("A ");
                Console.ReadKey();
            }
        }
        public class B : A
        {
            public B() : base()
            {
                Console.Write("B ");
                Console.ReadKey();
            }
        }
        B bugsy = new B();
    }
}
