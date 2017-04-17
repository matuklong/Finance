using Finance.Web3.Controllers;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.Mvc5;

namespace Finance.Web3.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            var container = new UnityContainer();            
            Finance.DependencyResolver.FinanceDependencyResolver.Resolve(container);
            UnityConfig.ResolveIUserStoreControllers(container);
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void ResolveIUserStoreControllers(UnityContainer container)
        {
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<HomeController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
        }
    }
}