namespace DIDemoWebAPI.Logging
{
    public class FileLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Лог в файл");
            // логіка запусу логу у файл
        }
    }
}
