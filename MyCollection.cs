using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10Lab;
using Лабораторная_работа_12_2;

namespace Лабораторная_работа_12_4
{
    public class MyCollection<T>:MyHashTable1<T>, IEnumerable<T>, ICollection<T> where T: IInit, ICloneable, new()
    {
        bool ICollection<T>.IsReadOnly => throw new NotImplementedException();

        //хеш-таблица с открытой адресацией
        public MyCollection():base() { }
        public MyCollection(int size) : base(size) { }

        public bool IsReadOnly() => false;//так как коллекция создается не только для чтения и изменяется

        public void Add(T item)
        {
            base.AddData(item);
        }

        public void Clear()
        {
            table = null;
            GC.Collect();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int index = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    array[arrayIndex + index] = (T)table[i].Clone(); // Используем Clone для копирования элементов
                    index++;
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    yield return table[i];
                }
            }
        }

        public bool Remove(T item)
        {
            base.RemoveData(item);
            return true;
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
