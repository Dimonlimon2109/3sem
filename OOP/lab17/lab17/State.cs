using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class ContextStrategy
    {
        private State _state = null;
        public ContextStrategy(State state)
        {
            this.TransitionTo(state);
        }
        public void TransitionTo(State state)
        {
            Console.WriteLine(state);
            this._state = state;
            this._state.SetContext(this);
        }
        public void Request1()
        {
            this._state.Handle1();
        }
        public void Request2()
        {
            this._state.Handle2();
        }
    }
    public abstract class State
    {
        protected ContextStrategy _context;
        public void SetContext(ContextStrategy context)
        {
            this._context = context;
        }
        public abstract void Handle1();
        public abstract void Handle2();
    }
    public class ConcreteStateA : State
    {
        private string state;
        public ConcreteStateA(string state)
        {
            this.state = state;
        }
        public override void Handle1()
        {
            Console.WriteLine("State: aplication is {0}", state);
            this._context.TransitionTo(new ConcreteStateB(state.Substring(3)));
        }
        public override void Handle2()
        {

        }
        public override string ToString()
        {
            return "Go to START state";
        }
    }
    public class ConcreteStateB : State
    {
        private string state;
        public ConcreteStateB(string state)
        {
            this.state = state;
        }
        public override void Handle1()
        {
            Console.WriteLine("Go to previos state\nState: {0}", state);
        }
        public override void Handle2()
        {
            Console.WriteLine("State: application is{0}", state);
            this._context.TransitionTo(new ConcreteStateA("not" + state));
        }
        public override string ToString()
        {
            return "Go to END state";
        }
    }
}
