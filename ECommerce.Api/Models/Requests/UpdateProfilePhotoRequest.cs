using Microsoft.AspNetCore.Http;
using System;

namespace ECommerce.Api.Models.Requests
{
    public class UpdateProfilePhotoRequest
    {
        public int Id { get; set; }
        public IFormFile File{ get; set; }
    }
}
