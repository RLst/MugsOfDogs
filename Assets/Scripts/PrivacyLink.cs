using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyLink : MonoBehaviour
{
    public string Url;

    public void OpenUrl()
    {
        Application.OpenURL(Url);
    }
}