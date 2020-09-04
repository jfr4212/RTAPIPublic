using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RightTriangleController : ControllerBase
    {
        // GET: api/<RightTriangleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { Get("A1") };
        }

        // GET api/<RightTriangleController>/D5
        [HttpGet("{coordinate}")]
        public string Get(string coordinate)
        {
            
            RightTriangle rt = new RightTriangle();

            return rt.CoordinateToRightTriangle(coordinate).Serialize();
        }

        // POST api/<RightTriangleController>
        [HttpPost]
        public string Post([FromBody] string jsonTriangle)
        {
            RightTriangle rt = new RightTriangle();

            string result = rt.RightTriangleToCoordinate(jsonTriangle);

            return result;
        }

    }
}
