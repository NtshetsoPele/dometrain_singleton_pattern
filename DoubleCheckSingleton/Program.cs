// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ParallelEnumerable
    .Range(start: 0, count: 10_000)
    .ForAll(action: _ =>
    {
        var __ = DoubleCheckSingleton.Instance;
    });

Console.WriteLine();

Console.WriteLine("Goodbye World, World!");

internal sealed class DoubleCheckSingleton
{
    private static DoubleCheckSingleton? _instance = default;
    private static readonly object Lock = new();

    public static DoubleCheckSingleton Instance
    {
        get
        {
            if (_instance is not null)
            {
                return _instance;
            }

            Console.WriteLine($"Locking. Thread: {Environment.CurrentManagedThreadId}.");

            lock (Lock)
            {
                Console.WriteLine($"Locked. Thread: {Environment.CurrentManagedThreadId}.");

                _instance ??= new DoubleCheckSingleton();
            }

            return _instance;
        }
    }

    private DoubleCheckSingleton() => Console.WriteLine($"Instantiating singleton. Thread: {Environment.CurrentManagedThreadId}.");
}