using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Config
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public int TokenLifetimeHours { get; set; }
    }
}
