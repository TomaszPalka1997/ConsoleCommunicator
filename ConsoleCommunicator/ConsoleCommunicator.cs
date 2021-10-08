using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCommunicator
{

    class ConsoleCommunicator
    {
        public ConsoleCommunicator()
        {
            start();
        }

        void start()
        {
            ConsoleInterface();
        }
        void ConsoleInterface()
        {
            Console.WriteLine("Welcome in ConsoleCommunicator, make a choice");
            Console.WriteLine("[1] to send a message");
            Console.WriteLine("[2] to ad new contact");
            Console.WriteLine("[3] to delete a contact");

            int choice_ = Int32.Parse(Console.ReadLine());

            ConsoleInterfaceSwitch(choice_);
        }

        void ConsoleInterfaceSwitch(int inputChoice)
        {
            switch (inputChoice)
            {
                case 1:
                    Console.WriteLine("u have typed [1]");
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
