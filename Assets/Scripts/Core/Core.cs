public static class Core
{
    public static ResourcesManager Resources
    {
        private set;
        get;
    }
    
    public static DataManger Data
    {
        private set;
        get;
    }
    
    public static EventManager Events
         {
             private set;
             get;
         }

    public static GameManager Game
    {
        private set;
        get;
    }
    
    static Core()
    {
        Resources = new();
        Data = new ();
        Events = new ();
        Game = new();
    }
}
