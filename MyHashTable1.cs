using ClassLibrary10Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_12_2
{
    public class MyHashTable1<T> where T : IInit, ICloneable, new()
    {
        public T[] table;//таблица
        int count = 0;//количество записей
        double fillRatio;//к-т заполняемости таблицы
        public int Capacity => table.Length;//выделенная память
        public int Count => count;//текущее кол-во элементов
        public MyHashTable1(int size=10, double fillRatio=0.72) //конструктор
        {
            table = new T[size];
            this.fillRatio = fillRatio;
        }

        public bool Contains(T data)
        {
            return !(FindItem(data) < 0);
        }
        public bool RemoveData(T data)
        {
            int index = FindItem(data);
            if (index < 0) return false;
            count--;
            table[index] = default;
            return true;
        }

        public void Print()
        {
            int i = 0;
            foreach(T item in table)
            {
                Console.WriteLine($"{i}:{item}");
                i++;
            }
        }
        public void AddItem(T item)
        {
            if((double)Count / Capacity > fillRatio)//место в таблице закончилось
            {
                T[] temp = (T[])table.Clone();//увеличиваем место и переписываем информацию
                table = new T[temp.Length * 2];
                count = 0;
                for (int i = 0; i < temp.Length; i++)
                    AddData(temp[i]);
            }
            AddData(item);//добавляем новый элемент
        }
        int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public void AddData(T data)
        {
            if (data == null) return; //добавляется пустой элемент
            int index = GetIndex(data);
            int current = index; //запомнили индекс
            if (table[index] != null) //уже занято
            {
                while (current < table.Length && table[current] != null)//идем до первого пустого места
                    current++;
                if(current  == table.Length)//если таблица закончилась
                {
                    current = 0;//идем от начала до идекса, который запомнили
                    while (current < index && table[current] != null) 
                        current++;
                    if(current == index)//места нет
                    {
                        throw new Exception("Нет места в таблице");
                    }
                }

            }
            table[current] = data;//место найдено
            count++;
        }

        public int FindItem(T data)
        {
            int index = GetIndex(data); //находим индекс
            if (table[index] == null) return -1; //если нет элемента
            if (table[index].Equals(data)) //есть элемент, совпадает
                return index;
            else //не совпадает
            {
                int current = index;//идем вниз
                while(current < table.Length)
                {
                    if (table[current] != null && table[current].Equals(data)) return current; //совпадает
                    current++;
                }
                current = 0;//идем с начала таблицы
                while(current < index)
                {
                    if (table[current] != null && table[current].Equals(data))//совпадает
                        return current;
                    current++;
                }
            }
            return -1;//не нашли
        }
    }
}
