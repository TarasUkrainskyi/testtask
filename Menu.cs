using System;
using System.Linq;
using TestTask.Helpers;

namespace TestTask
{
    public class Menu
    {
        private ManagerTest1 _manager1;
        private ManagerTest2 _manager2;

        public Menu()
        {
            _manager1 = new ManagerTest1();
            _manager2 = new ManagerTest2();
        }

        public void MainMenu()
        {
            while (true)
            {
                DisplayMainMenu();
                int number = InputHelper.ValidateDigitInput(Console.ReadKey(), Enumerable.Range(0, 9).ToArray());

                switch (number)
                {
                    case 1:
                        _manager1.OpenFileDialog();
                        break;
                    case 2:
                        _manager1.ShowPatterns();                        
                        break;
                    case 3:
                        _manager1.EditPatterns();
                        break;
                    case 4:
                        _manager1.ShowConvertedValues();
                        break;
                    case 5:
                        _manager1.SaveConvertedValues();
                        break;
                    case 6:
                        _manager2.OpenFileDialog();
                        break;
                    case 7:
                        _manager2.ShowValues();
                        break;
                    case 8:
                        _manager2.SaveValues();
                        break;
                    case 0:
                        Console.WriteLine("\nExit");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*    Menu for test 1 (convert to account number)    *");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("1. Import data from a file");
            Console.WriteLine("2. Display patterns");
            Console.WriteLine("3. Edit patterns");

            if (_manager1.IsImported())
            {
                Console.WriteLine("4. Display converted values");
                Console.WriteLine("5. Save to file converted values");
            }

            Console.WriteLine("\n");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*    Menu for test 2 (top 10 pizzas)                *");
            Console.WriteLine("*                                                   *");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("\n");
            Console.WriteLine("6. Import data from a file");

            if (_manager2.IsImported())
            {
                Console.WriteLine("7. Display top 10 values");
                Console.WriteLine("8. Save to file top 10 values");
            }

            Console.WriteLine("\n");
            Console.WriteLine("0. Exit");
            Console.WriteLine("\n");
        }
    }
}
