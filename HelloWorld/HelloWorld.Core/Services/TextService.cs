using HelloWorld.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Services
{
    public class TextService : ITextService
    {
        private IRepository _repository;

        public TextService(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetText()
        {
            return _repository.Get();
        }

        public void Insert(string text)
        {

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("Wrong value");

            _repository.Insert(text);

        }
    }
}
