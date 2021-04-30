using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model.DTO.Response
{
    public class UserResponse : DefaultResponse
    {
        public UserResponse() { }
        public UserResponse(string aUserId, string aEmail, List<ClaimDesc> aUserClaimList) 
        {
            UserId = aUserId;
            Email = aEmail;
            UserClaimList = aUserClaimList;
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<ClaimDesc> UserClaimList { get; set; }
    }

    public class ClaimDesc 
    {
        public ClaimDesc(string aKey, string aValue) 
        {
            Key = aKey;
            Value = aValue;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
