using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    // Контекст определяет интерфейс, представляющий интерес для клиентов.
    class NewContext
    {
        private IStrategy _strategy;
        public NewContext()
        { }
        public NewContext(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void DoStrategy(List<string> list)
        {
            var result = this._strategy.DoAlgorithm(list);

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + "\n";
            }

            Console.WriteLine(resultStr);
        }
    }
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }
    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }
}
