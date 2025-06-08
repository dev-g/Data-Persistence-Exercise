using UnityEngine;

public class PersistentDataManager : MonoBehaviour
{
    private static PersistentDataManager INSTANCE;

    private UserSettings _userSettings;
    private UserSettingsPersistence _userSettingsPersistence;

    private HighScores _highScores;
    private HighScoresPersistence _highScoresPersistence;

    public static HighScores HighScores => (INSTANCE != null) ? INSTANCE._highScores : null;


    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);

            _userSettingsPersistence = new(Application.persistentDataPath);
            _userSettings = _userSettingsPersistence.Load();

            _highScoresPersistence = new(Application.persistentDataPath);
            _highScores = _highScoresPersistence.Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static UserSettings GetUserSettings()
    {
        if (INSTANCE != null)
        {
            return INSTANCE._userSettings;
        }
        else
        {
            return null;
        }
    }

    public static void AddScore(int score)
    {
        if (INSTANCE != null)
        {
            INSTANCE._highScores.Add(new(INSTANCE._userSettings.UserName, score));
            INSTANCE._highScoresPersistence.Save(INSTANCE._highScores);
        }
    }

    public static void SaveUserSettings()
    {
        if (INSTANCE != null)
        {
            INSTANCE._userSettingsPersistence.Save(INSTANCE._userSettings);
        }
    }
}
