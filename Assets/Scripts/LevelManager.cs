using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /*
        // TreatSpawner Stacking Levels

        #region
        public void Level1()
        {
            SceneManager.LoadScene();
            Time.timeScale = 1;
        }

        public void Level2()
        {
            SceneManager.LoadScene();
            Time.timeScale = 1;
        }

        public void Level3()
        {
            SceneManager.LoadScene();
            Time.timeScale = 1;
        }

        public void Level4()
        {
            SceneManager.LoadScene();
            Time.timeScale = 1;
        }

        public void Level5()
        {
            SceneManager.LoadScene();
            Time.timeScale = 1;
        }
        #endregion
    */

    // Endless Stacking
/*
    #region
    public void EndlessStacking()
    {
        SceneManager.LoadScene();
        Time.timeScale = 1;
    }
    #endregion
*/

    // Feed the Puppies
    #region
    public void FeedingTime()
    {
        SceneManager.LoadScene(1);
    }
    #endregion

    /*
    // Puppy Boop
    #region
    public void BoopMiniGame()
    {
        SceneManager.LoadScene();
        Time.timeScale = 1;
    }
    #endregion
*/

}