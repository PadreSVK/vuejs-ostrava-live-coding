using FizzWare.NBuilder;
using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDataController : ControllerBase
    {
        private static readonly ILog mLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [Authorize(Policy = "IsAdmin")]
        public IEnumerable<EmployeeData> Get(string aFrom, string aTo)
        {
            var EmployeeList = Builder<EmployeeData>.CreateListOfSize(100)
                .All()
                    .With(e => e.FirstName = Faker.Name.First())
                    .With(e => e.LastName = Faker.Name.Last())
                    .With(e => e.EmailAddress = Faker.Internet.Email())
                    .With(e => e.PhoneNumber = Faker.Phone.Number())
                    .With(e => e.Prefix = Faker.Name.Prefix())
                    .With(e => e.Notes = Faker.Lorem.Sentence())
                    .With(e => e.Address = Faker.Address.StreetAddress())
                    .With(e => e.State = Faker.Address.UsState())
                    .With(e => e.City = Faker.Address.City())
                    .With(e => e.BirthDate = RandomDay())
                    .With(e => e.HireDate = RandomDay())
                .Random(30)
                    .With(e => e.EmailAddress = null)
                .Random(10)
                    .With(e => e.Address = null)
                    .With(e => e.State = null)
                    .With(e => e.City = null)
                .Build();

            return EmployeeList.ToArray();
        }

        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
