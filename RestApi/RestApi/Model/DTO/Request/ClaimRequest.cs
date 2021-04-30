using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Request
{
    public class ClaimRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string ClaimKey { get; set; }
        [Required]
        public string ClaimValue { get; set; }
    }
}
