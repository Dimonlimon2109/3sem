using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class Adapter : AbstractDispatcher
    {
        Tenant tenant;
        public Adapter(Tenant person)
        {
           tenant = person;
        }
        public object Create(string type_of_work, string scale, string periodOfTime, AbstractApplication application)
        {
            return new Brigade(application.Scale.Length, application.TypeOfWork);
        }
        public void CreateNote(AbstractBrigade brigade)
        {
            Plan.AddToPlan(brigade.Quantity.ToString(), brigade.TypeOfWork);
        }
    }
}
