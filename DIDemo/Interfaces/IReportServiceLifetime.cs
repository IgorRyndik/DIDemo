using Microsoft.Extensions.DependencyInjection;

namespace DIDemoConsole.Interfaces
{
    // базовий інтерфейс залежності
    public interface IReportServiceLifetime
    {
        Guid Id { get; }

        ServiceLifetime Lifetime { get; }
    }
}
