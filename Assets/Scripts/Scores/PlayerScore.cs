using System;
using System.Security.Authentication.ExtendedProtection.Configuration;
using UnityEngine;

[Serializable]
public class PlayerScore
{
    [SerializeField] private string _name;
    [SerializeField] private int _score;
    [SerializeField] private long _scoreTicks;

    public string Name => _name;
    public int Score => _score;
    public DateTime ScoreDate => new(_scoreTicks);

    public PlayerScore(string name, int score) : this(name, score, DateTime.Now) { }

    public PlayerScore(string name, int score, DateTime scoreDate)
    {
        _name = name;
        _score = score;
        _scoreTicks = scoreDate.Ticks;
    }
}
