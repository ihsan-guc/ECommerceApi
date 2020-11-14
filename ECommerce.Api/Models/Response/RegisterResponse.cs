using System;

namespace Message.Api.Models.Response
{
    public class RegisterResponse : BaseResponse
    {
        public string Token{ get; set; }
        public int Id{ get; set; }
    }
}
