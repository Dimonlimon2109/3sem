using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
     public interface IBuilder
    {
        void TenantBuilder();   
        void ApplicationBuilder();
        void DispatcherBuilder();
        void BrigadeBuilder();
    }
    public class Builder : IBuilder
    {
        private List<string> container = new List<string>();
        public Builder() 
        {
            this.Reset();
        }
        public void Reset()
        {
            this.container = new List<string>();
        }
        public void ApplicationBuilder()
        {
            Application application = new Application();
            container.Add(application.ToString());
        }
        public void BrigadeBuilder()
        {
            Brigade brigade = new Brigade();
            container.Add(brigade.ToString());
        }
        public void DispatcherBuilder()
        {
            Dispatcher dispatcher = new Dispatcher();
            container.Add(dispatcher.ToString());
        }
        public void TenantBuilder()
        {
            Tenant tenant = new Tenant();
            container.Add(tenant.ToString());
        }
        public List<string> GetProduct()
        {
            List<string> result = this.container;

            this.Reset();

            return result;
        }
    }
    public class Director
    {
        private IBuilder builder;
        public IBuilder Builder
        {
            set { builder = value; }
        }
        public void BuildTenantAndApplication()
        {
            this.builder.TenantBuilder();
            this.builder.ApplicationBuilder();
        }
        public void BuildDispatcherAndBrigade()
        {
            this.builder.DispatcherBuilder();
            this.builder.BrigadeBuilder();
        }
    }
}
