using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject GameOverMenu, PauseButton, TimerText, Spawner;
    public Text timerUI;
    public int countDownStartValue = 30;

    void OnEnable ()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            timerUI.text = "" + countDownStartValue;
            countDownStartValue--;
            Invoke("countDownTimer", 1f);
            Debug.Log("Timer : " + countDownStartValue);
        }

        if (countDownStartValue <= 0)
        {
            GameOverMenu.SetActive(true); //The UI "Game Over Menu" is open when it reches 0
            PauseButton.SetActive(false);
            TimerText.SetActive(false);
            Spawner.SetActive(false);
            Time.timeScale = 0;
        }
    }
}