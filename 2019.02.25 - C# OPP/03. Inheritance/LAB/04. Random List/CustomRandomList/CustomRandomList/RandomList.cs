﻿namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public string RemoveRandomString()
        {
            Random random = new Random();
            int index = random.Next(0, this.Count);
            string element = this[index];
            this.RemoveAt(index);

            return element;
        }
    }
}