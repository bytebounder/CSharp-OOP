﻿namespace StudentSystemCatalog.Data
{
    using System;

    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj); // Take and Print ToString Method from Student.ToString()
        }
    }
}