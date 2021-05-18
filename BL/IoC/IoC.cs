using DAL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class IoC
    {

       
        public static IKernel Kernel { get; private set; }

        public static void Setup()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        private static void AddBindings()
        {

            Kernel.Bind<IDal>().To<Dal>().InSingletonScope();
            Kernel.Bind<IAppLogic>().To<AppLogic>().InSingletonScope();
            Kernel.Bind<IAuth>().To<Auth>().InSingletonScope();

        }
    }
}
