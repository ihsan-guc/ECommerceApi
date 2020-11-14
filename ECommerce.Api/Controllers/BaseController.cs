using ECommerce.Data.DAL.Abstract;
using Message.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static ECommerce.Data.Domain.DataEnums.Enums;

namespace ECommerce.Api.Controllers
{
    public class BaseController : Controller
    {
        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get {
                if (unitOfWork == null)
                    unitOfWork = (IUnitOfWork)HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
                return unitOfWork; 
            }
        }

        [NonAction]
        public BaseResponse ReturnValid()
        {
            var response = new BaseResponse
            {
                IsSuccess = false,
                Type = ErrorType.Validation,
            };
            if (!ModelState.IsValid)
            {
                StringBuilder errorMessage;
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        errorMessage = new StringBuilder();
                        foreach (var message in state.Value.Errors)
                        {
                            errorMessage.AppendLine(message.ErrorMessage);
                        }
                        response.Message = errorMessage.ToString();
                    }
                }
            }
            return response;
        }
    }
}
