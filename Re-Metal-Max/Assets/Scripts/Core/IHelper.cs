using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMetalMax.Core
{
    public interface IHelper
    {
        Dictionary<string, ISource> Parse(string path = null);
    }
}
