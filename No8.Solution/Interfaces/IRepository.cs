using No8.Solution.Entities;

namespace No8.Solution.Interfaces
{
    public interface IRepository
    {
        void AddPrinter(Printer printer);
        void RemovePrinter(Printer printer);
    }
}
