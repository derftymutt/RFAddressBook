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
    [RoutePrefix("api/addresses")]
    public class AddressesApiController : ApiController
    {
        [Route("{userId:int}")]
        [HttpPost]
        public HttpResponseMessage Create(AddressCreateRequest model, int userId)
        {
            //model error check 

            //model.userId == userId(param) error check

            Guid id = AddressService.Create(model);
            ItemResponse<Guid> responseData = new ItemResponse<Guid>();
            responseData.Item = id;

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/{id}")]
        [HttpPut]
        public HttpResponseMessage Edit(AddressUpdateRequest model, int userId, Guid id)
        {
            //check to verify that model.userid and model.id = userid and id

            AddressService.Update(model);
            ItemResponse<int> responseData = new ItemResponse<int>();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}")]
        [HttpGet]
        public HttpResponseMessage Get(Address model, int userId)
        {
            //check if model is null

            //check if model.userId == userId..?

            ItemsResponse<Address> responseData = new ItemsResponse<Address>();
            responseData.Items = AddressService.Get(userId);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(Address model, int userId, Guid id)
        {
            ItemResponse<Address> responseData = new ItemResponse<Address>();
            responseData.Item = AddressService.Get(userId, id);

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }

        [Route("{userId:int}/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int userId, Guid id)
        {
            AddressService.Delete(userId, id);
            ItemResponse<int> responseData = new ItemResponse<int>();

            return Request.CreateResponse(HttpStatusCode.OK, responseData);
        }
    }
}
