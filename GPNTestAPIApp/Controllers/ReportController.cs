using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GPNTestWeb.Data;
using GPNTestWeb.Model.Enums;
using GPNTestWeb.Model.Entity;

namespace GPNTestAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;

			if (context.SaleItems.Count() == 0)
			{

				_context.SaleItems.Add(new SaleItem
				{
					Id = 1,
					Department = "DIT",
					Price = 100,
					Quarter = Quarter.First
				});

				_context.SaleItems.Add(new SaleItem
				{
					Id = 2,
					Department = "DIT",
					Price = 200,
					Quarter = Quarter.Second
				});

				_context.SaleItems.Add(new SaleItem
				{
					Id = 3,
					Department = "DIT",
					Price = 300,
					Quarter = Quarter.Third
				});

				_context.SaleItems.Add(new SaleItem
				{
					Id = 4,
					Department = "DIT",
					Price = 400,
					Quarter = Quarter.Fourths
				});
			}
			_context.SaveChanges();
		}

        [HttpGet("finance")]
		//[HttpGet("finance/{quarter:int}")]
		public async Task<ActionResult<FinanceReport>> GetFinanceReportItems(string name = "Финансовый отчет за квартал", int quarter = 1, string department = "DIT")
        {
            var test = _context.SaleItems.Count();

            var enumQuarter = (Quarter)(quarter - 1);

            var result = new FinanceReport(name, enumQuarter, department);
            result.Sales = await _context.SaleItems.Where(x=>x.Department.ToLower() == department.ToLower() && x.Quarter == enumQuarter).ToListAsync();


            return result;
        }
    }
}
