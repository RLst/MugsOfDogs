using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Animator anim;

    public static AnimationScript instance;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        anim.SetTrigger("EatingAnimation");
    }
}