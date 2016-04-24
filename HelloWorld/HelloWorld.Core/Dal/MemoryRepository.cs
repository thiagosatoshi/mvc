using HelloWorld.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Dal
{
    public class MemoryRepository : IRepository
    {
        private static List<string> _list;

        static MemoryRepository()
        {
            _list = new List<string>();
        }

        public List<string> Get()
        {
            return new List<string>(_list);
        }

        public void Insert(string text)
        {
            _list.Add(text);
        }
    }
}
