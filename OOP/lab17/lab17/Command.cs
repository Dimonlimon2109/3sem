using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public interface ICommand
    {
        void Execute();
    }
    class SimpleCommand : ICommand
    {
        private string _payload = string.Empty;
        public SimpleCommand(string payload)
        {
            this._payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: ({this._payload})");
        }
    }
    class ComplexCommand : ICommand
    {
        private Receiver _receiver;
        private string _a;
        private string _b;
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }
        public void Execute()
        {
            Console.WriteLine("ComplexCommand:");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver:({a}.)");
        }
        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver:({b}.)");
        }
    }
    class Invoker
    {
        private ICommand _onStart;
        private ICommand _onFinish;
        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }
        public void SetOnFinish(ICommand command)
        {
            this._onFinish = command;
        }
        public void DoSomethingImportant()
        {
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }
            if (this._onFinish is ICommand)
            {
                this._onFinish.Execute();
            }
        }
    }
}
