using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDetail : MonoBehaviour
{
    [SerializeField]
    private Text _nameText;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _dateText;

    public void SetDetail(string name, int score, DateTime date)
    {
        _nameText.text = name;
        _scoreText.text = score.ToString();
        _dateText.text = date.ToString();
    }

    public void SetBlank()
    {
        _nameText.text = "-";
        _scoreText.text = "-";
        _dateText.text = "-";
    }
}
