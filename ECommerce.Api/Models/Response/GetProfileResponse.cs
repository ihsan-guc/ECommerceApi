﻿namespace Message.Api.Models.Response
{
    public class GetProfileResponse : BaseResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}
