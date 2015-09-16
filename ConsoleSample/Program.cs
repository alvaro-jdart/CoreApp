using Jdart.ConsoleSample.Settings;
using Jdart.CoreApp;
using Jdart.CoreApp.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new SimpleApplication(new AppLogger());

            var config = app.SetDependency(new SwiffySettings())
                            .Build();

            var globalService = config.DependencyResolver.GetService<GlobalService>();

            globalService.Run();

            Console.ReadKey();
        }
    }
}
