using System.IO;
using UnityEngine;

public class UserSettingsPersistence
{
    private const string DEFAULT_FILE_NAME = "usersettings.json";
    private readonly string _filePath;

    public string FilePath => _filePath;

    public UserSettingsPersistence(string path, string fileName = DEFAULT_FILE_NAME)
    {
        _filePath = Path.Combine(path, fileName);
    }

    public void Save(UserSettings settings)
    {
        string json = JsonUtility.ToJson(settings, true);

        File.WriteAllText(_filePath, json);
    }

    public UserSettings Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);

            return JsonUtility.FromJson<UserSettings>(json);
        }
        else
        {
            return new();
        }
    }
}
