public class BaseSingleton<T> where T : BaseSingleton<T>, new()
{
    private static T CachedInstance;
    public static T Instance => CachedInstance ??= new();

    protected BaseSingleton()
    {
    }
}
