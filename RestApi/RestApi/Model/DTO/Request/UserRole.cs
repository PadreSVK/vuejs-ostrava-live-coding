using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Request
{
    public class UserRole
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
