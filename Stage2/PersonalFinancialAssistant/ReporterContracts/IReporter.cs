using System;
using System.Collections.Generic;
using System.Text;

namespace ReporterContracts
{
    public interface IReporter
    {
        void SaveReport(char[] report);
        object GetReport();
    }
}
