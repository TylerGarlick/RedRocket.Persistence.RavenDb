using System.Configuration;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Raven.Client.Document;

namespace RedRocket.Persistence.RavenDb
{
    public interface IDocumentStoreConfiguration
    {
        DocumentStore DocumentStore { get; }
    }

    [ContainerRegister(typeof(IDocumentStoreConfiguration), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.Singleton)]
    public class DocumentStoreConfiguration : IDocumentStoreConfiguration
    {
        public DocumentStoreConfiguration(DocumentStore documentStore)
        {
            DocumentStore = documentStore;
        }

        public DocumentStoreConfiguration()
        {
            DocumentStore = new DocumentStore() { ConnectionStringName = "RavenDbConnection" };
            DocumentStore.Initialize();
            DocumentStore.Conventions.IdentityPartsSeparator = "-";
        }

        public DocumentStore DocumentStore { get; private set; }
    }
}