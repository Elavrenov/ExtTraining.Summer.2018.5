using System;
using System.IO;

namespace No8.Solution.Entities
{
    public abstract class Printer
    {
        public string Name { get; }

        public string Model { get; }

        protected Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public virtual void Print(FileStream fileStream)
        {
            for (int i = 0; i < fileStream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(fileStream.ReadByte());
            }
        }

        public override string ToString()
        {
            return $"Printer:{Name} Model:{Model}";
        }
    }
}
