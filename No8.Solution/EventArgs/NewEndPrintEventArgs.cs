using System;

namespace No8.Solution.EventArgs
{
    public class NewEndPrintEventArgs : System.EventArgs
    {
        public string Printer { get; }
        public DateTime EndPrintTime { get; }
        public NewEndPrintEventArgs(string printer, DateTime endTime)
        {
            Printer = printer;
            EndPrintTime = endTime;
        }
    }
}
