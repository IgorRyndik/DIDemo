using DIDemoConsole.Interfaces;

namespace DIDemoConsole.Implementations
{
    class ExampleTransientService : IExampleTransientService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
