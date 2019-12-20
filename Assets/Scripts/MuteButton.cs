using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButton : MonoBehaviour
{
    static MuteButton instance = null;

    public Button MuteToggleButton;
    public Sprite MuteOnSprite, MuteOffSprite;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        UpdateMuteButtonIcon();
    }

    public void Mute()
    {
        //AudioListener.pause = !AudioListener.pause;
        ToggleSound();
        UpdateMuteButtonIcon();
    }

    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }

    void UpdateMuteButtonIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            GetComponent<Image>().sprite = MuteOnSprite;

        }
        else
        {
            AudioListener.volume = 0;
            GetComponent<Image>().sprite = MuteOffSprite;
        }
    }
}