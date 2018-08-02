using System;

namespace No8.Solution.EventArgs
{
    public class NewStartPrintEventArgs : System.EventArgs
    {
        public string Printer { get; }
        public DateTime StartPrintTime { get; }
        public NewStartPrintEventArgs(string printer, DateTime startTime)
        {
            Printer = printer;
            StartPrintTime = startTime;
        }
    }
}
