using Jdart.CoreApp.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.ConsoleSample
{
    public class AppLogger : IAppLogger
    {
        public void Error(Exception e)
        {
            File.AppendAllText("error.log", e.Message);
        }
    }
}
