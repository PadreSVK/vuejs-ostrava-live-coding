using FizzWare.NBuilder;
using log4net;
using Microsoft.AspNetCore.Mvc;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureDataController : ControllerBase
    {
        private static readonly ILog mLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public IEnumerable<TemperatureData> Get(string aFrom, string aTo)
        {
            var TemperatureList = Builder<TemperatureData>.CreateListOfSize(20)
                .All()
                    .With(a => a.Temperature = Faker.RandomNumber.Next(-5, 50))
                .Build();

            return TemperatureList.ToArray();
        }

        [HttpPost]
        [Route("PostTeste")]
        public IEnumerable<TemperatureData> PostTeste([FromBody] Filters aFilters)
        {
            var TemperatureList = Builder<TemperatureData>.CreateListOfSize(20)
                .All()
                    .With(a => a.Temperature = Faker.RandomNumber.Next(-5, 50))
                .Build();

            return TemperatureList.ToArray();
        }
    }
}
