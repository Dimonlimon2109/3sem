using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07
{
    interface IItems<T>
    {
        void Print(string message);
        void Add(T value);

        void Delete();
    }
}
