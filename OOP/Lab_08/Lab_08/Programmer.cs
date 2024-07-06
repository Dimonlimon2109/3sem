using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08
{
    class Programmer
    {
        public delegate void ProgrammerEventHandler(string message);
        public event ProgrammerEventHandler Rename;
        public event ProgrammerEventHandler NewProperty;
        private string name;
        public Programmer(string Name)
        {
            name = Name;
        }
        public void CommandAddOperation() => NewProperty.Invoke("Обработчик события NewProperty вызван");
        public void CommandRenameOperation() => Rename.Invoke("Обработчик события Rename вызван");
    }
}
