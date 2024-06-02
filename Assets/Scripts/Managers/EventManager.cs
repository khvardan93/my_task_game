using System;

public class EventManager
{
    public Action<string> OnClickCard;

    public Action<int> OnChangeScore;
    
    public Action<int> OnChangeLevel;
    
    public Action OnStartLevel;
    
    public Action OnCombo;

    public Action<int> OnFinishLevel;
}
