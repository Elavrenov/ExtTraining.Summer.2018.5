using System;
using No8.Solution.Entities;
using No8.Solution.Services;
using NUnit.Framework;

namespace No8.Solution.Tests
{
    [TestFixture]
    public class No8Tests
    {
        private PrinterManager pm = new PrinterManager();
        private Printer p1 = new CanonPrinter("Canon","22");
        private Printer p2 = new CanonPrinter("Canon","35-1");
        private CanonPrinter c1 = new CanonPrinter("Canon", "11");
        private CanonPrinter e1 = new CanonPrinter("Epson", "11");


        [TestCase(ExpectedResult = 5)]
        public int RepositoryAddTests1()
        {
            pm.AddPrinter(p1);
            pm.CreatePrinter("Canon","22");
            pm.AddPrinter(p2);
            pm.AddPrinter(c1);
            pm.AddPrinter(e1);

            return pm.PrintersCounter;
        }

        [TestCase(ExpectedResult = 3)]
        public int RepositoryRemoveTests()
        {
            pm.RemovePrinter(p1);
            pm.RemovePrinter(p2);

            return pm.PrintersCounter;
        }

        [Test]
        public void TryingToAddAvailablePrinterException()
        {
            Assert.Throws<InvalidOperationException>(() => pm.AddPrinter(e1));
        }

        [Test]
        public void TryingToAddNoValidPrinterException1()
        {
            Assert.Throws<ArgumentException>(() => pm.CreatePrinter(null,"11"));
        }

        [Test]
        public void TryingToAddNoValidPrinterException2()
        {
            Assert.Throws<NotImplementedException>(() => pm.CreatePrinter("prop", "11"));
        }

        [Test]
        public void TryingToAddNoValidPrinterException3()
        {
            Assert.Throws<ArgumentException>(() => pm.CreatePrinter("EPSON",null));
        }

        [Test]
        public void TryingToAddNoValidPrinterException4()
        {
            Assert.Throws<ArgumentException>(() => pm.CreatePrinter("EPSON",string.Empty));
        }
    }
}
