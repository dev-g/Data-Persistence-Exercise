using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenesList : MonoBehaviour
{
    [SerializeField]
    private List<ScoreDetail> _scoreDetails;

    private void Start()
    {
        var scores = PersistentDataManager.HighScores.GetAsArray();

        for (int i = 0; i < _scoreDetails.Count; ++i)
        {
            var detail = _scoreDetails[i];

            if (scores.Length > i)
            {
                var score = scores[i];
                detail.SetDetail(score.Name, score.Score, score.ScoreDate);
            }
            else
            {
                detail.SetBlank();
            }
        }
    }
}
