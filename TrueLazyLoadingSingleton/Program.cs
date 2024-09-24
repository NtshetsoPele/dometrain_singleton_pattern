// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.WriteLine(TrueLazyLoadingSingleton.ClassName);

ParallelEnumerable
    .Range(start: 0, count: 10_000)
    .ForAll(action: _ =>
    {
        var __ = TrueLazyLoadingSingleton.Instance;
    });

Console.WriteLine("Goodbye, World!");

internal sealed class TrueLazyLoadingSingleton
{
    public static string ClassName;
    public static TrueLazyLoadingSingleton Instance => Nested.Instance;

    private TrueLazyLoadingSingleton() => Console.WriteLine("Instantiated.");

    static TrueLazyLoadingSingleton() => ClassName = nameof(TrueLazyLoadingSingleton);

    private static class Nested
    {
        internal static readonly TrueLazyLoadingSingleton Instance;

        // 'beforefieldinit' removed from IL
        static Nested() => Instance = new TrueLazyLoadingSingleton();
    }
}