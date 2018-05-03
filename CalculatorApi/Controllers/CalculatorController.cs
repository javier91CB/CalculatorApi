using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/calculator")]
    public class CalculatorController : Controller
    {

        private readonly string route = "/api/v1/calculator/";
        // GET: api/Calculator
        [HttpGet("add/{*n}")]
        public long add(string nnn)
        {
            var paramValues = HttpContext.Request.Path.ToString().ToLower().Replace(route + "add/", "").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n: default(long);
            foreach (var value in paramValues?.Skip(1))
            {
                result += long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }

        // GET: api/Calculator/5
        [HttpGet("subs/{*n}")]
        public long subs()
        {
            var paramValues = HttpContext.Request.Path.ToString().ToLower().Replace(route + "subs/", "").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            foreach (var value in paramValues.Skip(1))
            {
                result -= long.TryParse(value, out long ne) ? ne : default(long);
            }
            return result;
        }

        // POST: api/Calculator
        [HttpGet("mult/{*n}")]
        public long mult()
        {
            var paramValues = HttpContext.Request.Path.ToString().ToLower().Replace(route + "mult/", "").Split('/');
            long result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            foreach (var value in paramValues.Skip(1))
            {
                result *= long.TryParse(value, out long ne) ? ne : default(long) + 1;
            }
            return result;
        }

        // PUT: api/Calculator/5
        [HttpGet("div/{*n}")]
        public string div()
        {
            var paramValues = HttpContext.Request.Path.ToString().ToLower().Replace(route + "div/", "").Split('/');
            double result = long.TryParse(paramValues?.First(), out long n) ? n : default(long);
            try
            {
                foreach (var value in paramValues.Skip(1))
                {
                    result /= long.TryParse(value, out long ne) ? ne : default(long) + 1;
                }
                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return("No Se Permite Division Entre 0");
            }
        }
    }
}
