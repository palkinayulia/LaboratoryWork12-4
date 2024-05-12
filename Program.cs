namespace Лабораторная_работа_12_4;
using ClassLibrary10Lab;
internal class Program
{
    static int NumberCheck() //проверка ввода числа
    {
        bool isConvert;
        int n;
        do
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();
            isConvert = int.TryParse(input, out n);
            if (!isConvert || n <= 0) Console.WriteLine("Неправильно введено число \nПопробуйте еще раз.");
        } while (!isConvert || n <= 0);
        return n;
    }
    static void Main(string[] args)
    {
        int size = 0;
        MyCollection<Watch> collection = new MyCollection<Watch>();

        int numberMenu;
        do //меню для 2 части
        {
            Console.WriteLine("1.Создать коллекцию");
            Console.WriteLine("2.Вывести коллекцию с помощью цикла foreach");
            Console.WriteLine("3.Вывести хеш-таблицу стандартно");
            Console.WriteLine("4.Удалить из таблицы элемент с заданым ключом");
            Console.WriteLine("5.Добавление элемента в коллекции");
            Console.WriteLine("6.Коллекция в массив");
            Console.WriteLine("7.Удаление из памяти");
            Console.WriteLine("8.Выход");
            numberMenu = NumberCheck();
            switch (numberMenu)
            {
                case 1: //создание таблицы
                    {
                        Console.Write("Введите количество элементов таблицы - ");
                        size = NumberCheck();
                        collection = new MyCollection<Watch>(size); //создаем таблицу
                        for (int i = 0; i < size; i++)
                        {
                            Watch c = new Watch();
                            c.RandomInit();
                            collection.AddItem(c);
                        }
                        Console.WriteLine("Коллекция создана");//сообщение для пользователя
                        break;
                    };
                case 2://печать таблицы циклом
                    {
                        foreach (Watch watch in collection)
                        {
                            Console.WriteLine(watch);
                        } //выводим таблицу
                        break;
                    };
                case 3://простой вывод хеш-таблицы
                    {
                        collection.Print();
                        break;
                    };
                case 4://удаление
                    {
                        Console.WriteLine("Введите элемент для удаления: ");
                        Watch clock = new Watch();
                        clock.Init();
                        if (!collection.Contains(clock)) Console.WriteLine("Такого элемента нет в коллекции");
                        else
                        {
                            collection.RemoveData(clock);
                            Console.WriteLine("Элемент удален"); //сообщение для пользователя
                        }
                        break;
                    };
                case 5://добавление
                    {
                        Console.WriteLine("Введите элемент для добавления: ");
                        Watch clock = new Watch();
                        clock.Init();
                        collection.Add(clock);
                        Console.WriteLine("Элемент добавлен");
                        break;
                    }
                case 6://создание массива
                    {
                        Watch[] arr = new Watch[collection.Count];
                        collection.CopyTo(arr, 0);
                        Console.WriteLine("Массив из коллекции: ");
                        for (int i = 0; i < arr.Length; i++)
                        {
                            Console.WriteLine(arr[i]);
                        }
                        break;
                    }
                case 7://очистка памяти
                    {
                        collection.Clear();
                        collection.Print();
                        Console.WriteLine("Коллекция удалена");
                        break;
                    }
                case 8: { break; } //возвращение в главное меню
                default: { Console.WriteLine("Неправильно задан пункт меню \nПопробуйте еще раз"); break; };
            }
        } while (numberMenu != 8);
    }
}
