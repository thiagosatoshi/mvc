using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Core.Abstract
{
    public interface ITextService
    {
        void Insert(string text);
        List<string> GetText();
    }
}
