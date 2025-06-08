using System.IO;
using UnityEngine;

public class HighScoresPersistence
{
    private const string DEFAULT_FILE_NAME = "highscores.json";
    private readonly string _filePath;

    public string FilePath => _filePath;

    public HighScoresPersistence(string path, string fileName = DEFAULT_FILE_NAME)
    {
        _filePath = Path.Combine(path, fileName);
    }

    public void Save(HighScores highScores)
    {
        string json = JsonUtility.ToJson(highScores, true);

        File.WriteAllText(_filePath, json);

        Debug.Log($"HighScores saved to: {_filePath}");
        Debug.Log($"content: {json}");
    }

    public HighScores Load()
    {
        if (!File.Exists(_filePath))
        {
            Debug.LogWarning("HighScores file not found.  Default used.");
            return new HighScores(10);
        }

        string json = File.ReadAllText(_filePath);

        Debug.Log($"HighScores loaded from: {_filePath}");
        Debug.Log($"content: {json}");

        return JsonUtility.FromJson<HighScores>(json);
    }

    public void DeleteSave()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
            Debug.Log("HighScores save file deleted.");
        }
    }
}
