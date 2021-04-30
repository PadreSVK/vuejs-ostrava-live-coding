using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Response
{
    public class AuthResult : DefaultResponse
    {
        public string Token { get; set; }   
    }
}
