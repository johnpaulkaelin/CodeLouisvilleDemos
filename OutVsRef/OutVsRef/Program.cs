using System;

namespace OutVsRef
{
    class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1;
            // notice we do NOT have a line like 
            // p1 = new Person("John")
            // you usually don't instantiate the out param before calling
            Console.WriteLine($"Before OutExample: ");
            if (OutExample(out p1))
                Console.WriteLine($"After OutExample: {p1.Name}\n");

            Person p2;
            // if you comment out the next two lines
            // you'll get a compile error.  With a ref param you must
            // instantiate before calling.
            p2 = new Person("John");
            Console.WriteLine($"Before RefExample: {p2.Name}");
            if (RefExample(ref p2))
                Console.WriteLine($"After RefExample: {p2.Name}\n");

            Person p3;
            // if you comment out the next two lines
            // you'll get a compile error, just like with ref param.  
            // but notice how the "After" value is affected when param is 
            // NOT a ref
            p3 = new Person("John");
            Console.WriteLine($"Before NotOutOrRefExample: {p3.Name}");
            if (NotOutOrRefExample(p3))
                Console.WriteLine($"After NotOutOrRefExample: {p3.Name}\n");

        }

        static bool OutExample(out Person p)
        {
            // uncomment the Console.WriteLine line below and you'll get an error.
            // because p is declared as an out param, .NET does not expect it to 
            // be instantiated when the function is first called.
            //Console.WriteLine($"Inside OutExample before new: {p.Name}");
            p = new Person("Rick");
            Console.WriteLine($"Inside OutExample after new: {p.Name}");
            return true;
        }

        static bool RefExample(ref Person p)
        {
            Console.WriteLine($"Inside RefExample before new: {p.Name}");
            p = new Person("Rick");
            Console.WriteLine($"Inside RefExample after new: {p.Name}");
            return true;
        }

        static bool NotOutOrRefExample(Person p)
        {
            Console.WriteLine($"Inside NotOutOrRefExample before new: {p.Name}");
            p = new Person("Rick");
            Console.WriteLine($"Inside NotOutOrRefExample after new: {p.Name}");
            return true;
        }
    }
}
