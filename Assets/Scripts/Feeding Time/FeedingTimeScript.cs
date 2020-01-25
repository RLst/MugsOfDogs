using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MugsOfDogs.Controllers;

public class FeedingTimeScript : MonoBehaviour
{
    //public AudioSource DestroySoundEffect;
    public GameObject DestroyParticle;

    private float min_X = -2f, max_X = 2f;

    private bool canMove;
    public float move_Speed = 9f;

    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myBody.gravityScale = 0f;
    }

    void Start()
    {
        canMove = true;

        if(Random.Range(0,2) > 0)
        {
            move_Speed *= -1f;
        }

        GameplayController.instance.currentTreat = this;
    }

    void FixedUpdate()
    {
        MoveTreat();
    }

    void MoveTreat()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;

            temp.x += move_Speed * Time.deltaTime;

            if (temp.x > max_X)
            {
                move_Speed *= -1f;
            }

            else if (temp.x < min_X)
            {
                move_Speed *= -1f;
            }

            transform.position = temp;
        }
    }

    public void DropTreat()
    {
        canMove = false;
        myBody.gravityScale = 3;
        //transform.Rotate(0, 0, 30); //I added a angle for the drop, but it's not good, I wanted to feel natural
    }

    void Landed ()
    {
        GameplayController.instance.SpawnNewTreat();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bowl")
        {
            Destroy(gameObject);
            Instantiate(DestroyParticle, transform.position, Quaternion.identity);
            Score.scoreValue += 1;
            GameplayController.instance.SpawnNewTreat();
            GameplayController.instance.PlaySound();
            //GameplayController.instance.PlayAnimation();
        }

        if (target.tag == "GameOver")
        {
            GameplayController.instance.EndGame();
            GameplayController.instance.SpawnNewTreat();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Score.scoreValue = 0;
        }
    }
}