using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0; // The "Enemy" script adds 1 point in here
    private Text score;
    public Text HighScore;

    void Start()
    {
        score = GetComponent<Text>();
        HighScore.text = PlayerPrefs.GetInt("★ ", 0).ToString();
    }

    void Update()
    {
        score.text = "" + scoreValue;
        HighScore.text = "★ " + PlayerPrefs.GetInt("★ ").ToString();

        if (scoreValue > PlayerPrefs.GetInt("★ ", 0))
        {
            PlayerPrefs.SetInt("★ ", scoreValue);
            HighScore.text = scoreValue.ToString();
        }
    }

    public void increaseScore()
    {
        score.text = "" + scoreValue;
    }
}