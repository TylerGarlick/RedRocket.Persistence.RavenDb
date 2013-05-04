using System.Collections.Generic;
using FlitBit.IoC.Meta;
using RedRocket.Persistence.RavenDb.Seeding;

namespace RedRocket.Persistence.RavenDb
{
    public interface IRavenBootstrapper
    {
        void Initialize();
    }
    
    [ContainerRegister(typeof(IRavenBootstrapper), RegistrationBehaviors.Default)]
    public class RavenBootstrapper : IRavenBootstrapper
    {
        readonly IEnumerable<IRavenEntityDataLoader> _ravenEntityDataLoaders;
        public RavenBootstrapper(IEnumerable<IRavenEntityDataLoader> ravenEntityDataLoaders)
        {
            _ravenEntityDataLoaders = ravenEntityDataLoaders;
        }

        public void Initialize()
        {
            var ravenDataLoader = _ravenEntityDataLoaders;
            foreach (var dataLoader in ravenDataLoader)
                dataLoader.Seed();
        }
    }
}