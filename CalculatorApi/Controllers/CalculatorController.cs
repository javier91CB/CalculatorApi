using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    public class CalculatorController : Controller
    {
        // GET: api/Calculator
        [HttpGet("add/{n?}")]
        public long add()
        {
            int count = HttpContext.Request.Path.ToString().LastIndexOf('/');
            var paramValues = HttpContext.Request.Path.ToString().Remove(0, count + 1).Replace("%2F", "/").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n: default(long);
            foreach (var value in paramValues?.Skip(1))
            {
                result += long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }

        // GET: api/Calculator/5
        [HttpGet("subs/{n?}")]
        public long subs()
        {
            int count = HttpContext.Request.Path.ToString().LastIndexOf('/');
            var paramValues = HttpContext.Request.Path.ToString().Remove(0, count + 1).Replace("%2F", "/").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            foreach (var value in paramValues.Skip(1))
            {
                result -= long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }

        // POST: api/Calculator
        [HttpGet("mult/{n?}")]
        public long mult()
        {
            int count = HttpContext.Request.Path.ToString().LastIndexOf('/');
            var paramValues = HttpContext.Request.Path.ToString().Remove(0, count + 1).Replace("%2F", "/").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            foreach (var value in paramValues.Skip(1))
            {
                result *= long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }

        // PUT: api/Calculator/5
        [HttpGet("div/{n?}")]
        public double div()
        {
            int count = HttpContext.Request.Path.ToString().LastIndexOf('/');
            var paramValues = HttpContext.Request.Path.ToString().Remove(0, count + 1).Replace("%2F", "/").Split('/');
            double result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            foreach (var value in paramValues.Skip(1))
            {
                result /= long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }
    }
}
