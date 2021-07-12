using GPNTestWeb.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPNTestWeb.Model.Entity
{
    public class FinanceReport : BaseReport
    {
        public string Department { get; set; }

        public int Sales_sum { get { if (this.Sales != null && this.Sales.Count > 0) { return Sales.Sum(x => x.Price); } else return 0; } }

        public FinanceReport(string name, Quarter quarter, string department) : base(name, quarter)
        {
            ReportName = name;
            ReportQuarter = quarter;
            Department = department;
        }
    }
}
