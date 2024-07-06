using System;
using System.Collections.Generic;
using System.Drawing;
namespace lab17
{
    public interface IPrototype
    {
        IPrototype Clone();
    }
    public class TenantPrototype : IPrototype
    {
        string name;
        string surname;
        string adress;
        public TenantPrototype()
        {
            name = "";
            surname = "";
            adress = "";
        }
        public TenantPrototype(string name, string surname, string adress)
        {
            this.name = name;
            this.surname = surname;
            this.adress = adress;
        }
        public string Name
        {
            get => name;
        }
        public string Surname
        {
            get => surname;
        }
        public string Adress
        {
            get => adress;
        }
        public IPrototype Clone()
        {
            return new TenantPrototype(this.name, this.surname, this.adress);
        }
        public override string ToString()
        {
            return "Tenant";
        }
    }
}
