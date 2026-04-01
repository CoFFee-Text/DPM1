using laba7;
class Program
{
    static void Main(string[] args)
    {
        EventMonitor monitor = new();
        monitor.OnMetricExceeded += e => Console.WriteLine($"Metric {e.Data.MetricName} is exceeded");
        // проверка метрик  ------- наблюдатель --------
        monitor.CheckMetric("CPU_Usage", 77, 70);
        monitor.CheckMetric("Memory_Usage", 49, 80);
        monitor.CheckMetric("Disk_Usage", 90, 85);

        // ------- стратегия -------
        TextFormatStrategy textStrategy = new TextFormatStrategy();
        JsonFormatStrategy jsonStrategy = new JsonFormatStrategy();

        var textHandler = new ConsoleHandler(textStrategy);
        var jsonHandler = new ConsoleHandler(jsonStrategy);

        monitor.OnMetricExceeded += textHandler.ProcessEvent;
        monitor.OnMetricExceeded += jsonHandler.ProcessEvent;
        Console.WriteLine("\nThe handlers are registered:\n- ConsoleHandler (text format)\n- ConsoleHandler (JSON format)\n");

        // ------- Шаблонный метод -------
        ConsoleHandler consoleHandler = new ConsoleHandler(textStrategy);
        FileHandler fileHandler = new FileHandler(textStrategy, "file1.txt");

        MetricData testData = new MetricData("CPU_Usage", 77, 70, DateTime.Now);
        MetricEventArgs testEvent = new MetricEventArgs("Exceeding the threshold", testData);

        consoleHandler.ProcessEvent(testEvent);
        fileHandler.ProcessEvent(testEvent);
    } 
}
