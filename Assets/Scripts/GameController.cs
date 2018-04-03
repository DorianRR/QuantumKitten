using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject mainCamera;
    public static GameController instance = null;
    public enum Level { Start, Middle, Boss}
    private bool objectiveState;
    private Level currentLevel;
    private GameObject level2Asteroids;
    private GameObject level2Exit;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        currentLevel = Level.Start;
        objectiveState = false;
        level2Asteroids = GameObject.Find("Level2Asteroids");
        level2Exit = GameObject.Find("level2Exit");
        level2Exit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
       if(currentLevel == Level.Start)
       {

       }
       else if (currentLevel == Level.Middle)
       {
            if(checkAsteroids())
            {
                spawnExitHole();
            }
            else
            {

            }
       }
       else if(currentLevel == Level.Boss)
       {

       }

       if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("testint");
            mainCamera.GetComponent<BlackHoleEffect>().gameObject.SetActive(true);

        }


    }



    public void changeLevel(Level newLevel)
    {
        currentLevel = newLevel;
        objectiveState = false;
    }


    private bool checkAsteroids()
    {
        if (level2Asteroids.transform.childCount == 0) 
        {
            Debug.Log("asteroids down");
            return true;

        }
        else
        {
            return false;
        }
    }

    private void spawnExitHole()
    {
        level2Exit.SetActive(true);
    }
  
}
