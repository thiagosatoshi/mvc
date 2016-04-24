using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Core.Abstract;

namespace HelloWorld.MVC.Controllers
{
    public class TextController : Controller
    {
        private ITextService _service;

        public TextController(ITextService service)
        {
            _service = service;
        }

        public HttpResponseMessage Insert(string text)
        {
            _service.Insert(text);

            var responseMessage = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NoContent };
            return responseMessage;
        }

        public ActionResult GetText()
        {
            var result = _service.GetText();

            var response = new HttpResponseMessage();
            response.StatusCode = System.Net.HttpStatusCode.OK;
            
            response.Content = new StringContent(System.Web.Helpers.Json.Encode(result));

            return Json(result);
        }
    }
}