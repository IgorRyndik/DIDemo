using Microsoft.Extensions.DependencyInjection;

namespace DIDemoConsole.Interfaces
{
    // інтерфейс залежності з життєвим циклом Transient,
    // кожен раз при запиті залежності буде створюватися новий екзампляр класу
    public interface IExampleTransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
