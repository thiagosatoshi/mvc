using HelloWorld.Core.Abstract;
using HelloWorld.Core.Services;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.MVC.Tests.Services
{
    [TestFixture]
    public class TextServiceShould
    {
        private TextService _service;
        private IRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IRepository>();
            _service = new TextService(_repository);
        }

        [TestCase("T1")]
        [TestCase("T2")]
        public void Insert(string text)
        {
            _service.Insert(text);
            _repository.Received(1).Insert(text);
        }

        [TestCase("T1")]
        [TestCase("T2")]
        public void Get(string text)
        {
            _repository.Get().Returns(new List<string> { text, text });

            var texts = _service.GetText();

            texts.All(x => x == text).ShouldBeTrue();
        }


        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("		")]
        public void Validate_Text(string text)
        {
            ShouldThrowExtensions.ShouldThrow<ArgumentNullException>(() =>
             _service.Insert(text)
            );

            _repository.Received(0).Insert(Arg.Any<string>());
        }
    }
}
