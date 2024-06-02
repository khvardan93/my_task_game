using System;

public class EventManager
{
    public Action<string> OnClickCard;

    public Action<int> OnChangeScore;
    
    public Action<int> OnChangeLevel;
}
