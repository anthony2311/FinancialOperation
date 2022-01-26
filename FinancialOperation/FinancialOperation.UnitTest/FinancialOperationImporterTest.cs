using FinancialOperation.lib;
using NUnit.Framework;
using System;

namespace FinancialOperation.UnitTest
{
    public class FinancialOperationImporterTest
    {
        [Test]
        public void Report_success()
        {
            var result = FinancialOperationImporter.Report("P65\nR15\nF3\nL\nP45\n");
            Assert.AreEqual($"Balance: 45 euros{Environment.NewLine}" +
                $"Total fees: 3 euros{Environment.NewLine}" +
                "Transferred to recipient: 47 euros",
                result);
        }
        [Test]
        public void ReportWithDecimal_success()
        {
            var result = FinancialOperationImporter.Report("P65.6\nR15.2\nF3\nL\nP45\n");
            Assert.AreEqual($"Balance: 45 euros{Environment.NewLine}" +
                $"Total fees: 3 euros{Environment.NewLine}" +
                "Transferred to recipient: 47,4 euros",
                result);
        }
        [Test]
        public void ReportWithInvalidOperation_throwAnError()
        {
            Assert.Throws<InvalidOperationException>(() => FinancialOperationImporter.Report("P65\nW15\nF3\nL\nP45\n"));
        }
    }
}