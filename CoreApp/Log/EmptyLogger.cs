using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Log
{
    internal class EmptyLogger : IAppLogger
    {
        public void Error(Exception e)
        {
        }
    }
}
