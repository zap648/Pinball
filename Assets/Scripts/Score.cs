using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textScore;
    [SerializeField] int score;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string fullScore = LeadingZero(score);
        textScore.text = $"Score: {fullScore}";
    }

    public void AddScore(int In)
    {
        score += In;
    }

    public int GetScore()
    {
        return score;
    }

    string LeadingZero(int In)
    {
        return In.ToString().PadLeft(6, '0');
    }
}
