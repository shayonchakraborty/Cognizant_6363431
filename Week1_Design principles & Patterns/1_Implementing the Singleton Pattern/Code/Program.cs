using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("Shayon");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Chakraborty");

        Console.WriteLine(Object.ReferenceEquals(logger1, logger2)
            ? "Same instance confirmed"
            : "Different instances - error in Singleton pattern");
    }
}
