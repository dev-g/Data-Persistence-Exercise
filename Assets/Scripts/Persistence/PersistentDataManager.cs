using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public class UserSettings
    {
        private const string UNSET_NAME = "UNSET";
        public string UserName = UNSET_NAME;
    }

    private static DataPersistence INSTANCE;
    private UserSettings _userSettings;
    private HighScores _highScores;

    private HighScoresPersistence _highScoresPersistence;


    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(gameObject);

            _userSettings = new();
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

    public static HighScores HighScores => (INSTANCE != null) ? INSTANCE._highScores : null;

}
