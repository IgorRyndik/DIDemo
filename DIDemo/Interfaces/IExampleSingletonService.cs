using Microsoft.Extensions.DependencyInjection;

namespace DIDemoConsole.Interfaces
{
    /// <summary>
    /// Інтерфейс залежності з життєвим циклом Singleton,
    /// один и той самий екземпляр буде використано у всьому застосунку
    /// </summary>
    public interface IExampleSingletonService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
