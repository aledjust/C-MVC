using ArtistsCRUD.Abstract;
using ArtistsCRUD.Concrete;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ArtistsCRUD
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAlbumRepository, AlbumRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}