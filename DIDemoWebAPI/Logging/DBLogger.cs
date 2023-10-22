namespace DIDemoWebAPI.Logging
{
    /// <summary>
    /// Одна з реалізацій залежності
    /// </summary>
    public class DBLogger : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Лог у базу даних");
            // логіка запису в базу даних
        }
    }
}
