using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using No8.Solution.Entities;
using No8.Solution.EventArgs;
using No8.Solution.Interfaces;

namespace No8.Solution.Services
{
    public class PrinterManager : IRepository, IService
    {
        #region Fields and prop

        private List<Printer> _printers = new List<Printer>();

        public event EventHandler<NewStartPrintEventArgs> NewStartPrint;
        public event EventHandler<NewEndPrintEventArgs> NewEndPrint;

        public int PrintersCounter => _printers.Count;

        #endregion

        #region Public API

        public void AddPrinter(Printer printer)
        {
            CheckPrinterAvailability(printer);
            _printers.Add(printer);
            Logger.WriteLog($"{printer.ToString()} add in repository");
        }

        public void RemovePrinter(Printer printer)
        {
            _printers.Remove(printer);

        }

        public void CreatePrinter(string name, string model)
        {
            Logger.WriteLog($"User trying to create new printer");

            var printer = PrinterCreator.Create(name, model);
            CheckPrinterAvailability(printer);
            _printers.Add(printer);

            Logger.WriteLog($"{printer.ToString()} add in repository");
        }

        public void Print(FileStream fileStream, Printer printer)
        {
            Logger.WriteLog($"User print file {fileStream.Name} through {printer.ToString()}");

            var eventStart = new NewStartPrintEventArgs(printer.ToString(), DateTime.Now);
            this.OnNewStartPrint(eventStart);

            printer.Print(fileStream);
            Thread.Sleep(3000);

            var eventEnd = new NewEndPrintEventArgs(printer.ToString(), DateTime.Now);
            this.OnNewEndPrint(eventEnd);
        }

        public void GetPrinterList()
        {
            int i = 0;
            foreach (var printer in _printers)
            {
                Console.WriteLine($"{++i}: {printer}");
            }
        }

        #endregion

        #region Protected virlual events methods

        protected virtual void OnNewStartPrint(NewStartPrintEventArgs e)
        {
            var temp = NewStartPrint;
            temp?.Invoke(this, e);
        }
        protected virtual void OnNewEndPrint(NewEndPrintEventArgs e)
        {
            var temp = NewEndPrint;
            temp?.Invoke(this, e);
        }


        #endregion

        #region Private methods

        private void CheckPrinterAvailability(Printer printer)
        {
            if (_printers.Contains(printer))
            {
                Logger.WriteLog($"Attempt to add available {printer}");
                throw new InvalidOperationException($"{nameof(printer)} printer is already exist");
            }
        }

        #endregion 
    }
}
