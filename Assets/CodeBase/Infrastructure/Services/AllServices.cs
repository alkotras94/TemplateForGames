using Assets.CodeBase.AssetManagment;
using Assets.CodeBase.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _container;
        public static AllServices Container => _container ?? (_container = new AllServices());

        public void RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implemenatation<TService>.ServicInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implemenatation<TService>.ServicInstance;

        public static class Implemenatation<TService> where TService : IService
        {
            public static TService ServicInstance;
        }
    }
}
