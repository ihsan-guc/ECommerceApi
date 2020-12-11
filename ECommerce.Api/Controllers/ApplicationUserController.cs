using ECommerce.Api.Core;
using ECommerce.Api.Models.Requests;
using ECommerce.Data.Domain.Entities;
using Message.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        ITokenGenerator TokenGenerator;
        IUploadFile UploadFile;
        public ApplicationUserController(ITokenGenerator tokenGenerator, IUploadFile uploadFile)
        {
            TokenGenerator = tokenGenerator;
            UploadFile = uploadFile;
        }
        /// <summary>
        /// Kullanıcı Kayıt eder
        /// </summary>
        /// <param name="Register"></param>
        /// Post: api/ApplicationUser/register
        [HttpPost]
        [Route("register")]
        public ActionResult Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Password = model.Password,
                    Id = UnitOfWork.ApplicationUserRepository.ApplicationUserCount() + 1
                };


                var token = new Token()
                {
                    Id = UnitOfWork.ApplicationUserRepository.ApplicationUserCount() + 1 ,
                    ApplicationUserId = user.Id,
                    TokenString = TokenGenerator.Token(user.UserName, user.Email)
                };
                user.TokenId = token.Id;

                UnitOfWork.ApplicationUserRepository.Add(user);
                UnitOfWork.TokenRepository.Add(token);
                UnitOfWork.Commit();
                return Ok(new RegisterResponse() { IsSuccess = true, Message = "Başarılı", Token = token.TokenString, Id = user.Id });
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kullanıcı Girişi
        /// </summary>
        /// <param name="Login"></param>
        /// Post: api/ApplicationUser/login
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login(LoginRequest model)
        {
            var user = UnitOfWork.ApplicationUserRepository.GetQueryable().Where(p => p.Email == model.Email && p.Password == model.Password).FirstOrDefault();
            if (user == null)
                return Ok(ReturnValid());
            else
            {
                var token = UnitOfWork.TokenRepository.GetById(user.TokenId);
                token.TokenString = TokenGenerator.Token(user.UserName, user.Email);
                UnitOfWork.Commit();
                return Ok(new LoginResponse()
                {
                    IsSuccess = true,
                    Token = token.TokenString,
                    Message = "Başarılı",
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Id = user.Id,
                    Image = user.Image
                });
            }
        }

        /// <summary>
        /// Resim ekler
        /// </summary>
        /// <param name="updateProfilePhotoRequest"></param>
        /// Post: api/ApplicationUser/UploadFileImage
        [HttpPost]
        [Route("UploadFileImage")]
        public ActionResult UploadFileImage([FromForm] UpdateProfilePhotoRequest updateProfilePhotoRequest)
        {
            if (ModelState.IsValid)
            {
                var profile = UnitOfWork.ApplicationUserRepository.GetById(updateProfilePhotoRequest.Id);
                if (profile != null)
                {
                    var imageName = UploadFile.UploadFileImage(updateProfilePhotoRequest.File, updateProfilePhotoRequest.Id);
                    if (imageName != null)
                    {
                        profile.Image = imageName;
                        UnitOfWork.Commit();
                    }
                    return Ok(new BaseResponse() { IsSuccess = true, Message = "Başarılı" });
                }
            }
            return Ok(ReturnValid());
        }

        /// <summary>
        /// Kullanıcı Günceller
        /// </summary>
        /// <param name="ApplicationUserUpdate"></param>
        /// Post: api/ApplicationUser/applicationUserUpdate
        [HttpPost]
        [Route("applicationUserUpdate")]
        public ActionResult ApplicationUserUpdate(ApplicaitionUserUpdateRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = UnitOfWork.ApplicationUserRepository.GetById(model.Id);
                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Password = model.Password;
                user.Email = model.Email;
                UnitOfWork.Commit();
                return Ok(new BaseResponse() { IsSuccess = true, Message = "Başarılı" });
            }
            return Ok(ReturnValid());
        }
        ///// <summary>
        ///// Kullanıcı Arama
        ///// </summary>
        ///// <param name="ApplicationSearch"></param>
        ///// Post: api/ApplicationUser/ApplicationSearch
        //[HttpPost]
        //[Route("ApplicationSearch")]
        //public ActionResult ApplicationSearch(SearchRequest model)
        //{
        //    var userList = UnitOfWork.ApplicationUserRepository.SearchApplicationUserList(model.SearchText);
        //    if (userList.Count() > 0)
        //    {
        //        return Ok(new SearchResponse() { IsSuccess = true, Message = "Başarılı", ApplicationUsersList = userList.ToList() });
        //    }
        //    return Ok(new SearchResponse() { IsSuccess = false, Message = "Aradaığınız kullanıcı yok", ApplicationUsersList = null });
        //}

        /// <summary>
        /// Kullanıcı Siler
        /// </summary>
        /// <param name="Delete"></param>
        /// Post: api/ApplicationUser/delete
        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var user = UnitOfWork.ApplicationUserRepository.GetById(id);
                var token = UnitOfWork.TokenRepository.GetById(id);
                UnitOfWork.ApplicationUserRepository.Delete(user);
                UnitOfWork.TokenRepository.Delete(token);
                UnitOfWork.Commit();
                return Ok(new BaseResponse() { IsSuccess = true, Message = "Başarılı" });
            }
            return Ok(ReturnValid());
        }
        /// <summary>
        /// Kullanıcı Profil
        /// </summary>
        /// Post: api/ApplicationUser/delete
        [HttpPost]
        [Route("getprofile")]
        public ActionResult GetProfileUser(GetProfileRequest getProfileRequest)
        {
            if (ModelState.IsValid)
            {
                var profile = UnitOfWork.ApplicationUserRepository.GetById(getProfileRequest.UserId);
                if (profile != null)
                {
                    var response = new GetProfileResponse()
                    {
                        Email = profile.Email,
                        FirstName = profile.FirstName,
                        LastName = profile.LastName,
                        UserName = profile.UserName,
                        Message = "Başarılı",
                        IsSuccess = true,
                    };
                    return Ok(response);
                }
            }
            return Ok(ReturnValid());
        }
    }
}
