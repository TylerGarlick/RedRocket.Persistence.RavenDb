using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Raven.Client.Document;

namespace RedRocket.Persistence.RavenDb
{
    public interface IRavenDbConfiguration
    {
        DocumentStore DocumentStore { get; }
    }

    [ContainerRegister(typeof(IRavenDbConfiguration), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.Singleton)]
    public class RavenDbConfiguration : IRavenDbConfiguration
    {
        public DocumentStore DocumentStore { get; private set; }

        // DocumentStore = new DocumentStore
        //                        {
        //                            ConnectionStringName = "RavenDbConnection",
        //                            Conventions =
        //                                {
        //                                    IdentityPartsSeparator = "-",
        //                                    AllowQueriesOnId = true
        //                                }
        //                        };

        public RavenDbConfiguration(DocumentStore documentStore)
        {
            DocumentStore = documentStore;
            DocumentStore.Initialize();
        }
    }
}