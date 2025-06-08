using NUnit.Framework;
using System;
using System.IO;
using UnityEngine;

[TestFixture]
public class HighScoresPersistenceTests
{
    private const string FILE_NAME_FOR_TESTING = "highscores_unit_test.json";
    private HighScoresPersistence _persistence;

    [SetUp]
    public void SetUp()
    {
        // Make sure each test starts with a clean state
        _persistence = new(Application.persistentDataPath, FILE_NAME_FOR_TESTING);

        if (File.Exists(_persistence.FilePath))
        {
            File.Delete(_persistence.FilePath);
        }
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the file after test
        if (File.Exists(_persistence.FilePath))
        {
            File.Delete(_persistence.FilePath);
        }
    }

    [Test]
    public void SaveLoad_ReturnsEquivalentHighScores()
    {
        var original = new HighScores(3, new[]
        {
            new PlayerScore("Alice", 100, new DateTime(2023, 1, 1)),
            new PlayerScore("Bob", 150, new DateTime(2023, 1, 2)),
            new PlayerScore("Charlie", 120, new DateTime(2023, 1, 3))
        });

        _persistence.Save(original);
        HighScores loaded = _persistence.Load();

        Assert.NotNull(loaded);

        var originalArray = original.GetAsArray();
        var loadedArray = loaded.GetAsArray();

        Assert.AreEqual(originalArray.Length, loadedArray.Length);

        for (int i = 0; i < originalArray.Length; i++)
        {
            Assert.AreEqual(originalArray[i].Name, loadedArray[i].Name, $"Name mismatch at index {i}");
            Assert.AreEqual(originalArray[i].Score, loadedArray[i].Score, $"Score mismatch at index {i}");
            Assert.AreEqual(originalArray[i].ScoreDate, loadedArray[i].ScoreDate, $"Date mismatch at index {i}");
        }
    }

    [Test]
    public void Load_MissingFile_ReturnsEmptyHighScores()
    {
        var persistence = new HighScoresPersistence(FILE_NAME_FOR_TESTING);
        HighScores result = persistence.Load();

        Assert.NotNull(result);
        Assert.AreEqual(0, result.GetAsArray().Length);
    }

    [Test]
    public void Should_SerializePlayerScore_When_Requested()
    {
        var score = new PlayerScore("Alice", 100, new DateTime(2023, 1, 1));
        var serialized = JsonUtility.ToJson(score);

        Debug.Log($"Serialized form: {serialized}");

        var deserialized = JsonUtility.FromJson<PlayerScore>(serialized);

        Assert.IsNotNull(deserialized);
        Assert.AreEqual(score.Name, deserialized.Name);
        Assert.AreEqual(score.Score, deserialized.Score);
        Assert.AreEqual(score.ScoreDate, deserialized.ScoreDate);
    }
}
