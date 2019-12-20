using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    void Awake()
    {
        //Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;
    }

    void Start ()
    {
        Time.timeScale = 1;
        Score.scoreValue = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Restart()
    {
        //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}