 namespace lab17
{
    public interface IAbstractFactory
    {
        object Create(string type_of_work, string scale, string periodOfTime, AbstractApplication application);
    }

    public interface AbstractTenant : IAbstractFactory
    {
        string Name { get; }
        string Surname { get; }
        string Adress { get; }
    }
    public class Tenant : AbstractTenant
    {
        private string name;
        private string surname;
        private string adress;
        public Tenant()
        {
            name = "";
            surname = "";
            adress = "";
        }
        public Tenant(string name, string surname, string adress)
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
        public object Create(string type_of_work, string scale, string periodOfTime, AbstractApplication application = null)
        {
            return new Application(type_of_work, scale, periodOfTime);
        }
        public override string ToString()
        {
            return "Tenant";
        }
    }

    public interface AbstractApplication
    {
        public string TypeOfWork { get; }
        public string Scale { get; }
        public string PeriodOfTime { get; }
    }
    public class Application : AbstractApplication
    {
        private string type_of_work;
        private string scale;
        private string periodOfTime;
        public Application()
        {
            type_of_work = "";
            scale = "";
            periodOfTime = "";
        }
        public Application(string type_of_work, string scale, string periodOfTime)
        {
            this.type_of_work = type_of_work;
            this.scale = scale;
            this.periodOfTime = periodOfTime;
        }
        public string TypeOfWork
        {
            get => type_of_work;
        }
        public string Scale
        {
            get => scale;
        }
        public string PeriodOfTime
        {
            get => periodOfTime;
        }
        public override string ToString()
        {
            return "Application";
        }
    }

    public interface AbstractDispatcher : IAbstractFactory
    {
        void CreateNote(AbstractBrigade brigade);
    }
    public class Dispatcher : AbstractDispatcher
    {
        public Dispatcher()
        {

        }
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
            return "Dispatcher";
        }
    }

    public interface AbstractBrigade
    {
        public int Quantity { get; }
        public string TypeOfWork { get; }
    }
    public class Brigade : AbstractBrigade
    {
        private int quantity;
        private string typeOfWork;
        public Brigade()
        {
            quantity = 0;
            typeOfWork = "";
        }
        public Brigade(int quantity, string typeOfWork)
        {
            this.quantity = quantity;
            this.typeOfWork = typeOfWork;
        }
        public int Quantity
        {
            get => quantity;
        }
        public string TypeOfWork
        {
            get => typeOfWork;
        }
        public override string ToString()
        {
            return "Brigade";
        }
    }
}
