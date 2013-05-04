using FlitBit.Core;
using FlitBit.IoC;

namespace RedRocket.Persistence.RavenDb.Seeding
{
    public abstract class AbstractRavenEntityDataLoader<T> : IRavenEntityDataLoader
    {
        protected readonly IRepository<T> Repository;
        protected readonly DataGenerator Generator;

        protected AbstractRavenEntityDataLoader(IRepository<T> repository)
        {
            Repository = repository;
            Generator = Create.New<DataGenerator>();
        }

        public abstract void Seed();
    }
}