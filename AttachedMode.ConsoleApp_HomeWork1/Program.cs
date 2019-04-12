using AttachedMode.Services_HomeWork1;
using System;

namespace AttachedMode.ConsoleApp_HomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatedDB createdDB = new CreatedDB(){ Reporter = new ConsoleReporter() };
            CreateTableDB createTableDB = new CreateTableDB() { Reporter = new ConsoleReporter() };
            DropDataBase dropDataBase = new DropDataBase();

            createdDB.CreatedDataBase();
            createTableDB.CreateTable();
            Console.WriteLine("\n\nНажмите любую клавишу");
            Console.ReadKey();

                int choice=0;
            while (choice==0)
            {
                Console.Clear();
                Console.WriteLine("\nУдалить БД?\n 1 - да\n 2 - нет");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        dropDataBase.Drop();
                        Console.WriteLine("БД удалена!!!");
                        break;
                    case 2:
                        break;
                    default:
                        choice = 0;
                        continue;
                }
            }

            Console.ReadKey();
        }
    }
}
