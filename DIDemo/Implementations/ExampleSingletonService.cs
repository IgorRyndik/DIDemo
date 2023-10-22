using DIDemoConsole.Interfaces;

namespace DIDemoConsole.Implementations
{
    class ExampleSingletonService : IExampleSingletonService
    {
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
