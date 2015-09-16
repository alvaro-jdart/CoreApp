using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Log
{
    public interface IAppLogger
    {
        void Error(Exception e);
    }
}
