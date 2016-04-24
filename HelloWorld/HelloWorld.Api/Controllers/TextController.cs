using HelloWorld.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.Api.Controllers
{
    public class TextController : ApiController
    {
        private ITextService _service;

        public TextController(ITextService service)
        {
            _service = service;
        }

        [HttpPost, Route("insert")]
        public HttpResponseMessage Insert(string text)
        {
            _service.Insert(text);

            var responseMessage = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NoContent };
            return responseMessage;
        }

        [HttpGet, Route("get")]
        public HttpResponseMessage GetText()
        {
            var result = _service.GetText();

            var response = new HttpResponseMessage();
            response.StatusCode = System.Net.HttpStatusCode.OK;

            response.Content = new StringContent(System.Web.Helpers.Json.Encode(result));

            return response;
        }
    }
}
