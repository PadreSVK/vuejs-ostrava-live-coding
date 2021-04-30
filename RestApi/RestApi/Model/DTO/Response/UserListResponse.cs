using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Response
{
    public class UserListResponse : DefaultResponse
    {
        public List<UserResponse> UserList { get; set; }
    }
}
