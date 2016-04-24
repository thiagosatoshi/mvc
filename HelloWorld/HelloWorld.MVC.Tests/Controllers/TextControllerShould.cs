using HelloWorld.Core.Abstract;
using HelloWorld.MVC.Controllers;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace HelloWorld.MVC.Tests.Controllers
{
    [TestFixture]
    public class TextControllerShould
    {
        private TextController _controller;
        private ITextService _service;

        [SetUp]
        public void Setup()
        {
            _service = Substitute.For<ITextService>();
            _controller = new TextController(_service);
        }

        [TestCase("texto teste")]
        [TestCase("texto teste2")]
        [TestCase("texto teste3")]
        [TestCase("texto teste4")]
        public void Receive_And_Save_Text(string text)
        {
            var response = _controller.Insert(text);

            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
            _service.Received(1).Insert(text);
        }

        [TestCase("texto teste")]
        [TestCase("texto teste2")]
        [TestCase("texto teste3")]
        [TestCase("texto teste4")]
        public void Get_All_Sent_Text(string text)
        {
            //_service.GetText().Returns(new List<string> { text, text });

            //var response = _controller.GetText();

            //response.StatusCode.ShouldBe(HttpStatusCode.OK);

            //var content = response.Content.ReadAsStringAsync().Result;
            //var responseTextList = Json.Decode<List<string>>(content);

            //responseTextList.All(x => x == text).ShouldBeTrue();
        }
    }
}
