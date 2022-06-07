using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "mono","di","tri","tetra"
        };

        [HttpGet]
        public IEnumerable<Test> Get()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new Test
            {
                Date = DateTime.Now.AddDays(index)
            })
            .ToArray();
        }

    }
}