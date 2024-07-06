using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public abstract class AbstractPerson
    {
        public AbstractPerson(string name) 
        { 
            this.Name = name;
        }
        public string Name { get; protected set; }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Person : AbstractPerson
    {
        public Person(string name) : base(name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return "Person: " + Name;
        }
    }
    public abstract class PersonDecorator : Person
    {
        protected Person person;
        public PersonDecorator(Person person, string name) : base(name)
        {
            this.person = person;
        }
    }
    public class DecorTenant : PersonDecorator
    {
        public DecorTenant(Person person, string name, string surname, string adress) : base(person, name)
        {
            this.Surname = surname;
            this.Adress = adress;
        }
        public string Surname { get; protected set; }
        public string Adress { get; protected set;}
        public object Create(string type_of_work, string scale, string periodOfTime, AbstractApplication application = null)
        {
            return new Application(type_of_work, scale, periodOfTime);
        }
        public override string ToString()
        {
            return "Tenant: " + Name + " " + Surname + " " + Adress + "\nMethods: Create()";
        }
    }
    public class DecorDespatcher : PersonDecorator
    {
        public DecorDespatcher(Person person, string name) : base(person, name) { }
        public object Create(string type_of_work, string scale, string periodOfTime, AbstractApplication application)
        {
            return new Brigade(application.Scale.Length, application.TypeOfWork);
        }
        public void CreateNote(AbstractBrigade brigade)
        {
            Plan.AddToPlan(brigade.Quantity.ToString(), brigade.TypeOfWork);
        }
        public override string ToString()
        {
            return "Despatcher: " + Name + "\nMethods: Create(), CreateNote()";
        }
    }
}
