using GPNTestWeb.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPNTestWeb.Model.Entity
{
    public class SaleItem
    {
        public long Id { get; set; }

        public string Department { get; set; }

        public int Price { get; set; }

        public Quarter Quarter { get; set; }
        public int IQuarter { get; set; }
    }
}
