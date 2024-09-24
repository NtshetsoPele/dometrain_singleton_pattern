// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ParallelEnumerable
    .Range(start: 0, count: 10_000)
    .ForAll(action: _ =>
    {
        var __ = NaiveSingleton.Instance;
    });

Console.WriteLine("Goodbye World, World!");

internal sealed class NaiveSingleton
{
    private static NaiveSingleton? _naiveSingleton = default;

    public static NaiveSingleton Instance => _naiveSingleton ??= new();
    
    private NaiveSingleton() => Console.WriteLine("Initiating NaiveSingleton.");
}