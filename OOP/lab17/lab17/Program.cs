using System.Numerics;

namespace lab17
{
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractFactory tenant = new Tenant("andrew", "badboy", "haven");
            Dispatcher dispatcher = new Dispatcher();

            dispatcher.CreateNote((AbstractBrigade)dispatcher.Create("", "", "", (AbstractApplication)tenant.Create("paint", "10m * 5m", "11:00 - 12:00", null)));
            Console.WriteLine("~abstract factory~");
            foreach(var note in Plan.GetPlan()) Console.WriteLine(note);

            Console.WriteLine("~builder~");
            Director director = new Director();
            Builder builder = new Builder();
            director.Builder = builder;
            director.BuildTenantAndApplication();
            foreach (var note in builder.GetProduct()) Console.Write(note + " ");
            Console.WriteLine();
            director.BuildDispatcherAndBrigade();
            foreach (var note in builder.GetProduct()) Console.Write(note + " ");

            Console.WriteLine("\n\n~singleton~");
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine(s2.GetHashCode() + " " + s1.GetHashCode());

            Console.WriteLine("\n~prototype~");
            IPrototype item = new TenantPrototype("kostya", "godboy", "hell");
            IPrototype clone = item.Clone();
            Console.WriteLine(item.ToString() + " " + clone.ToString());
            //-----------------------------------------------------------------------------------------------------------
            Console.WriteLine("\n~adapter~");
            Tenant tenant_for_adapter = new Tenant("andrew", "badboy", "haven");
            AbstractDispatcher adapter_dispatcher = new Adapter(tenant_for_adapter);

            Console.WriteLine("\n~decorator~");
            Person person = new Person("bob");
            Console.WriteLine(person);
            person = new DecorTenant(person, person.Name, "qwerty", "london");
            Console.WriteLine(person);
            person = new DecorDespatcher(person, person.Name);
            Console.WriteLine(person);

            Console.WriteLine("\n~command~");
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Tenant: create application"));
            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Despatcher: create brigade", "Despatcher: create note"));
            invoker.DoSomethingImportant();

            Console.WriteLine("\n~state~");
            var context = new ContextStrategy(new ConcreteStateA("not done"));
            context.Request1();
            context.Request2();
            context.Request1();

            Console.WriteLine("\n~strategy~");
            var newcontext = new NewContext();
            List<string> list = new List<string>()
            {
                "2. create brigade",
                "1. create aplication",
                "3. create note"
            };
            newcontext.SetStrategy(new ConcreteStrategyA());
            Console.WriteLine("first strategy:");
            newcontext.DoStrategy(list);
            newcontext.SetStrategy(new ConcreteStrategyB());
            Console.WriteLine("second startegy");
            newcontext.DoStrategy(list);
        }
    }
}