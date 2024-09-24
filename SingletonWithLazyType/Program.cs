// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!\n");

ParallelEnumerable
    .Range(start: 0, count: 10_000)
    .ForAll(action: _ =>
    {
        var __ = SingletonWithLazyType.Instance;
    });

Console.WriteLine("\nGoodbye World, World!");

internal sealed class SingletonWithLazyType
{
    private static readonly Lazy<SingletonWithLazyType> LazyInstance;

    public static SingletonWithLazyType Instance => LazyInstance.Value;

    private SingletonWithLazyType() => Console.WriteLine("Instantiating singleton");

    static SingletonWithLazyType() => LazyInstance = new(() => new());
}