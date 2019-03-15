namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackOfStrings : List<string>
    {
        public void Push(string element)
        {
            this.Add(element);
        }

        public string Pop()
        {
            string element = GetLastElement();
            RemoveAt(Count - 1);

            return element;
        }

        public string Peek()
        {
            return GetLastElement();
        }

        public bool IsEmpty()
        {
            return this.Count < 1;
        }

        private string GetLastElement()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            return this.Last();
        }
    }
}