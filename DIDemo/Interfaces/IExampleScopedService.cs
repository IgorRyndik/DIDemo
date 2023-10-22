using Microsoft.Extensions.DependencyInjection;

namespace DIDemoConsole.Interfaces
{
    /// <summary>
    /// Інтерфейс залежності з життєвим циклом Scoped,
    /// один и той самий екземпляр буде використано у рамках екземплюра, що будет впроваджувати залежність
    /// </summary>
    public interface IExampleScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
