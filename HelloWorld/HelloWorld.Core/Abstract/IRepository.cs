using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Abstract
{
    public interface IRepository
    {
        void Insert(string text);
        List<string> Get();
    }
}
