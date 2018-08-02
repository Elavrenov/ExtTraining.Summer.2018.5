using System.IO;
using No8.Solution.Entities;

namespace No8.Solution.Interfaces
{
    public interface IService
    {
        void CreatePrinter(string name, string model);
        void Print(FileStream fileStream, Printer printer);
        void GetPrinterList();
    }
}
