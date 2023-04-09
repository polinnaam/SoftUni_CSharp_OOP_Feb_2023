using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    internal class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;
        
        public StackOfStrings()
        {
            this.stack = new Stack<string>();
        }

        public bool IsEmpty()
        {
            return stack.Any();
        }
        public void AddRange(List<string> collection)
        {
            foreach (var item in collection)
            {
                this.stack.Push(item);
            }
        }

    }
}
