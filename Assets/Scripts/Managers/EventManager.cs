using System;
using System.Collections.Generic;

public class EventManager
{
    public Action<string> OnClickCard;

    public Action<int> OnChangeScore;
    
    public Action<int> OnChangeLevel;
    
    public Action OnStartLevel;
    public Action<List<CardData>> OnStartSavedLevel;
    
    public Action OnCombo;

    public Action<int> OnFinishLevel;
    
    public Action OnMatch;
    
    public Action OnMismatch;
}