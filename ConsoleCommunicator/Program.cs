using System;

namespace ConsoleCommunicator
{
    class Program
    {
        void ConsoleInterface ()
        {
            Console.WriteLine("Hello in ConsoleCommunicator, make a choice");
            Console.WriteLine("[1] to send a message");
            Console.WriteLine("[2] to ad new contact");
            Console.WriteLine("[3] to delete a contact");
           
        }

        void ConsoleInterfaceSwitch(int inputChoice)
        {
            switch (inputChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
