using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jdart.CoreApp.Extensions
{
    public static class AppOptionsExtensions
    {
        public static AppOptions<TContainer, TContainer> ToCommonOptions<TContainer>(this AppOptions<TContainer> options)
        {
            var commonOptions = new AppOptions<TContainer, TContainer>
            {
                DependencyContainer = options.DependencyContainer,
                GetServiceFunc = c => options.GetServiceFunc,
                GetAllServicesFunc = c => options.GetAllServicesFunc,
                Logger = options.Logger
            };

            if (options.VerifyAction != null)
            {
                commonOptions.VerifyAction = c => { options.VerifyAction(c); return c; };
            }
            else
            {
                commonOptions.VerifyAction = c => c;
            }

            return commonOptions;
        }
    }
}
