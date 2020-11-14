using Microsoft.AspNetCore.Http;
using System;

namespace ECommerce.Api.Models.Requests
{
    public class GetProfileRequest
    {
        public int UserId { get; set; }
    }
}
