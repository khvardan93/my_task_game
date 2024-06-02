public static class Configs
{
    #region RESOURCES
    public const string CARD_PREFAB_PATH = "Prefabs/CardPrefab";
    public const string CARD_SPRITE_PATH = "Sprites/Cards";
    public const string CARD_BACK_SPRITE_PATH = "Sprites/CardBack";
    public const string LEVELS_PATH = "Levels";
    #endregion

    #region LAYERS
    public const string CARD_LAYER = "Card";
    #endregion

    #region DATA KEYS
    public const string SCORE_DATA_KEY = "score";
    public const string CURRENT_LEVEL_DATA_KEY = "current_level";
    public const string SAVED_LEVEL_DATA = "saved_level";
    #endregion

    #region GAME SETTINGS
    public const float CARD_OPEN_DURATION = 1.0f;
    public const float CARD_DESTROY_DURATION = 0.5f;
    public const float CARD_PREVIEW_DURATION = 0.75f;

    public const float COMBO_INTERVAL = 0.5f;
    public const int REWARD_PER_COMBO = 2;
    #endregion

    #region UI
    public const float FINISH_POPUP_OPEN_DELAY = 0.5f;
    public const float COMBO_ANIM_DURATION = 0.75f;
    #endregion
}
