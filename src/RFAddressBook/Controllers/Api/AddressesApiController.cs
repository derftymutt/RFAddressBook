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
        [Route("{userId}")]
        [HttpPost]
        public HttpResponseMessage Create(string userId)
        {
            return null;
        }

        [Route("{userId}/{int:id}")]
        [HttpPut]
        public HttpResponseMessage Edit(string userId, int id)
        {
            return null;
        }

        [Route("{userId}")]
        [HttpGet]
        public HttpResponseMessage Get(string userId)
        {
            return null;
        }

        [Route("{userId}/{int:id}")]
        [HttpGet]
        public HttpResponseMessage Get(string userId, int id)
        {
            return null;
        }

        [Route("{userId}/{int:id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string userId, int id)
        {
            return null;
        }
    }
}
