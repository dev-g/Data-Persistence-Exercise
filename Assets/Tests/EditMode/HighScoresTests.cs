using NUnit.Framework;
using System;
using System.Collections.Generic;

public class HighScoresTests
{
    [Test]
    public void Initialization_SortsAndTrims()
    {
        var scores = new List<PlayerScore>
        {
            new("Alice", 50, new DateTime(2023, 1, 1)),
            new("Bob", 70, new DateTime(2023, 1, 2)),
            new("Charlie", 70, new DateTime(2023, 1, 1)),
            new("Dave", 30, new DateTime(2023, 1, 1))
        };

        var highScores = new HighScores(3, scores);
        var result = highScores.GetAsArray();

        Assert.AreEqual(3, result.Length);
        Assert.AreEqual("Charlie", result[0].Name);
        Assert.AreEqual("Bob", result[1].Name);
        Assert.AreEqual("Alice", result[2].Name);
    }

    [Test]
    public void Add_ScoreMaintainsOrderAndSize()
    {
        var scores = new List<PlayerScore>
        {
            new("Alice", 50, new DateTime(2023, 1, 1)),
            new("Bob", 70, new DateTime(2023, 1, 2)),
        };

        var highScores = new HighScores(3, scores);

        highScores.Add(new PlayerScore("Charlie", 90, new DateTime(2023, 1, 3)));
        highScores.Add(new PlayerScore("Dave", 40, new DateTime(2023, 1, 1)));

        var result = highScores.GetAsArray();

        Assert.AreEqual(3, result.Length);
        Assert.AreEqual("Charlie", result[0].Name);
        Assert.AreEqual("Bob", result[1].Name);
        Assert.AreEqual("Alice", result[2].Name);
    }

    [Test]
    public void TieScores_SortedByDate()
    {
        var scores = new List<PlayerScore>
        {
            new("A", 100, new DateTime(2023, 5, 2)),
            new("B", 100, new DateTime(2023, 5, 1)),
            new("C", 90, new DateTime(2023, 5, 3))
        };

        var highScores = new HighScores(3, scores);
        var result = highScores.GetAsArray();

        Assert.AreEqual("B", result[0].Name);
        Assert.AreEqual("A", result[1].Name);
        Assert.AreEqual("C", result[2].Name);
    }
}
