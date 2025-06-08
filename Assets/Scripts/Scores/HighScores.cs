using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScores
{
    [SerializeField] private int _maxSize;
    [SerializeField] private List<PlayerScore> _scores;
    public List<PlayerScore> Scores => _scores;

    public HighScores(int maxSize) : this(maxSize, new PlayerScore[0]) { }

    public HighScores(int maxSize, IEnumerable<PlayerScore> initialScores)
    {
        _maxSize = maxSize;
        _scores = new List<PlayerScore>(initialScores);
        TrimAndSort();
    }

    public void Add(PlayerScore playerScore)
    {
        _scores.Add(playerScore);
        TrimAndSort();
    }

    public PlayerScore[] GetAsArray()
    {
        return _scores.ToArray();
    }

    private void TrimAndSort()
    {
        _scores.Sort(CompareScores);

        if (_scores.Count > _maxSize)
        {
            _scores.RemoveRange(_maxSize, _scores.Count - _maxSize);
        }
    }

    private static int CompareScores(PlayerScore a, PlayerScore b)
    {
        int scoreComparison = b.Score.CompareTo(a.Score);

        if (scoreComparison != 0)
        {
            return scoreComparison;
        }

        return a.ScoreDate.CompareTo(b.ScoreDate);
    }
}
