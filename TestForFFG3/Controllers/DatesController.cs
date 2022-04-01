using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestForFFG3.Models;
using System.Linq;

namespace TestForFFG3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesController : ControllerBase
    {
        private readonly DbCntxt _context;

        public DatesController(DbCntxt context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatesInterval>>> GetInterval()
        {
            var dates = await _context.dates.ToListAsync();

            var numbers = from date in dates
                          orderby date.Id ascending
                          select date;

            var dateInterval = new List<DatesInterval>();

            var numbersArray = numbers.ToArray();

            for (int i = 0; i < numbersArray.Length-1; i++)
            {
                if (numbersArray[i].Id != numbersArray[i + 1].Id )
                    i++;

                dateInterval.Add(new DatesInterval
                    {
                        Id = numbersArray[i].Id,
                        Sd = numbersArray[i].Date,
                        Ed = numbersArray[i+1].Date
                    });
                
            }

            return dateInterval;
        }
    }
}
