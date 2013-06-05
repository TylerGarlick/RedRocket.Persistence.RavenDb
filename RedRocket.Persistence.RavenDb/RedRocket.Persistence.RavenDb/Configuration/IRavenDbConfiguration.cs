using Raven.Client.Document;

namespace RedRocket.Persistence.RavenDb.Configuration
{
    public interface IRavenDbConfiguration
    {
        DocumentStore DocumentStore { get; }
    }
}