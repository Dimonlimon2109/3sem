using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Application
    {
        private string type_of_work;
        private string scale;
        private DateTime day_of_work;
        public Application()
        {

        }
        public Application(string type_of_work, string scale, DateTime day_of_work)
        {
            this.day_of_work = day_of_work;
            this.type_of_work=type_of_work;
            this.scale = scale;
        }
    }
}
