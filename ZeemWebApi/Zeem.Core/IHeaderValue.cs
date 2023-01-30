using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeem.Core.Domain;

namespace Zeem.Core
{
    public interface IHeaderValue
    {
        ZeemUser CurrentUser { get; }
    }
}
