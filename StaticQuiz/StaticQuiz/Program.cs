using System;

namespace StaticQuiz
{
    public class TestClass
    {
        // static property with initial value of 0
        public static int StaticProperty { get; set; } = 0;

        // non-static property with initial value of 0
        public int NonStaticProperty { get; set; } = 0;

        // every time we create an instance of TestClass
        // increment the StaticProperty AND the NonStaticProperty
        public TestClass()
        {
            StaticProperty++;
            NonStaticProperty++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = null;
            for(int i = 0; i < 10; i++)
            {
                test = new TestClass();
            }
            Console.WriteLine($"test.NonStaticProperty = {test.NonStaticProperty}");
            Console.WriteLine($"Test.StaticProperty = {TestClass.StaticProperty}");
        }
    }
}
