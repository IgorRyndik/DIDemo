using DIDemoConsole.Interfaces;

namespace DIDemoConsole.Implementations
{
    class ExampleScopedService : IExampleScopedService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
