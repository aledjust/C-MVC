using Album.API.DataAccess;
using Unity;
using Unity.Extension;

namespace Album.API.Business.App_Start.DIContainer
{
    public class DependencyOfDependecyExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IArtistsDataAccess, ArtistsDataAccess>();            
        }
    }
}
