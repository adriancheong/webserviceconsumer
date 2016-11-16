using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebserviceConsumer.Model;

namespace Game1.Controllers
{
    [Route("[controller]")]
    public class TwoThirdAverageController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return TwoThirdAverageGame.GetTwoThirdOfAverage().ToString();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Submission value)
        {
            if (value != null)
                TwoThirdAverageGame.Submit(value.Number);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
