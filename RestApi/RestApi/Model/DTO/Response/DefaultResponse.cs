using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Response
{
    public class DefaultResponse
    {
        public bool Result { get; set; }
        public List<string> Errors { get; set; }
    }
}
