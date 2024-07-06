using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorking
{
    public class MyCollection<T> : List<T>
    {
        List<T> list = new List<T>();
        public bool Add(T element)
        {
           list.Add(element);
            return true;
        }
        public bool Find (T element)
        {
            if(list.Contains(element)) return true;
            else return false;
        }
    }
}
