using UnityEngine;
using TMPro;

public class HiScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI hiScore;
    public int score;
    //public int hiScoreVal;


    private void Start()
    {
        hiScore.text = "HI SCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString("00000000");
        score = FindObjectOfType<GameSession>().GetScore();
        Debug.Log(score);
    }

    private void Update()
    {
        
        SetHiScore(score);
    }

    void SetHiScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            hiScore.text = "HI SCORE: " + score.ToString("00000000");
        }
    }

}
