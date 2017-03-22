using RFAddressBook.Controllers.Api;
using RFAddressBook.Domain;
using RFAddressBook.Models.Requests;
using RFAddressBook.Models.Responses;
using RFAddressBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RFAddressBook.Controllers.ApiControllers
{
    [RoutePrefix("api/users")]
    public class UserAddressesApiController : BaseApiController
    { 
        private IAddressService _addressService;

        public UserAddressesApiController (IAddressService addressService)
        {
            _addressService = addressService;
        }

        [Route("{userId:int}/addresses"), HttpPost]
        public HttpResponseMessage Create(AddressCreateRequest model, int userId)
        {

            if (!IsValidRequest(model))
            {
                return GetErrorResponse(model);
            }

            if (userId != model.UserId)
            {
                ErrorResponse error = new ErrorResponse("The userId in the route and request do not match");
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }

            Guid id = _addressService.Create(model);
            ItemResponse<Guid> responseData = new ItemResponse<Guid>();
            responseData.Item = id;

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}"), HttpPut]
        public HttpResponseMessage Update(AddressUpdateRequest model, int userId, Guid id)
        {
            if (!IsValidRequest(model))
            {
                return GetErrorResponse(model);
            }
            
            if(userId != model.UserId)
            {
                ErrorResponse error = new ErrorResponse("The userId in the route and request do not match");
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }

            if (id != model.Id)
            {
                ErrorResponse error = new ErrorResponse("The Id in the route and request do not match");
                return Request.CreateResponse(HttpStatusCode.BadRequest, error);
            }

            _addressService.Update(model);
            SuccessResponse responseData = new SuccessResponse();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses"), HttpGet]
        public HttpResponseMessage Get(int userId)
        {

            ItemsResponse<Address> responseData = new ItemsResponse<Address>();
            responseData.Items = _addressService.Get(userId);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}"), HttpGet]
        public HttpResponseMessage Get(int userId, Guid id)
        {

            ItemResponse<Address> responseData = new ItemResponse<Address>();
            responseData.Item = _addressService.Get(userId, id);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}"), HttpDelete]
        public HttpResponseMessage Delete(int userId, Guid id)
        {

            _addressService.Delete(userId, id);

            SuccessResponse responseData = new SuccessResponse();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }
    }
}
