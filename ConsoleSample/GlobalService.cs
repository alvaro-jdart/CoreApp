using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.ConsoleSample
{
    public class GlobalService
    {
        private readonly Swiffy.SwiffyClient _swiffyClient;

        public GlobalService(Swiffy.SwiffyClient swiffyClient)
        {
            _swiffyClient = swiffyClient;
        }

        public void Run()
        {

        }
    }
}
