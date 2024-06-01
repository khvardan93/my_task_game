using System;

public class EventManager
{
    private static EventManager CachedInstance;
    public static EventManager Instance => CachedInstance ??= new();
    private EventManager() { }

    public Action<string> OnClickCard;
}
