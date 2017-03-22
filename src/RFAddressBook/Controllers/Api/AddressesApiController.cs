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
    public class AddressesApiController : ApiController
    {

        private IAddressService _addressService;

        public AddressesApiController (IAddressService addressService)
        {
            _addressService = addressService;
        }

        [Route("{userId:int}/addresses")]
        [HttpPost]
        public HttpResponseMessage Create(AddressCreateRequest model, int userId)
        {
            //model error check 

            //model.userId == userId(param) error check

            Guid id = _addressService.Create(model);
            ItemResponse<Guid> responseData = new ItemResponse<Guid>();
            responseData.Item = id;

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}")]
        [HttpPut]
        public HttpResponseMessage Edit(AddressUpdateRequest model, int userId, Guid id)
        {
            //check to verify that model.userid and model.id = userid and id

            _addressService.Update(model);
            SuccessResponse responseData = new SuccessResponse();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses")]
        [HttpGet]
        public HttpResponseMessage Get(int userId)
        {
            //check if model is null

            //check if model.userId == userId..?

            ItemsResponse<Address> responseData = new ItemsResponse<Address>();
            responseData.Items = _addressService.Get(userId);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}")]
        [HttpGet]
        public HttpResponseMessage Get(int userId, Guid id)
        {
            ItemResponse<Address> responseData = new ItemResponse<Address>();
            responseData.Item = _addressService.Get(userId, id);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/addresses/{id:guid}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int userId, Guid id)
        {
            _addressService.Delete(userId, id);

            SuccessResponse responseData = new SuccessResponse();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }
    }
}
