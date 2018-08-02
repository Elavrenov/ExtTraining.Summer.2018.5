using System;
using No8.Solution.Entities;

namespace No8.Solution.Services
{
    public static class PrinterCreator
    {
        public static Printer Create(string name, string model)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} can't be null or empty");
            }

            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentException($"{nameof(model)} can't be null or empty");
            }

            switch (name.ToLower())
            {
                case "canon":
                    return new CanonPrinter(name,model);
                case "epson":
                    return new EpsonPrinter(name,model);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
