using GPNTestWeb.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPNTestWeb.Model.Entity
{
    public class BaseReport
    {
        public string ReportName { get; set; }
        public Quarter ReportQuarter { get; set; }

        public List<SaleItem> Sales { get; set; }

        public BaseReport(string name, Quarter quarter)
        {
            ReportName = name;
            ReportQuarter = quarter;
        }
    }
}
