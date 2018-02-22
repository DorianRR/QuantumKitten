using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void puzzle1()
    {
        SceneManager.LoadScene("testLevel1");
    }
    public void puzzle2()
    {
        SceneManager.LoadScene("testLevel2");
    }
    public void freeRoam()
    {
        SceneManager.LoadScene("FreeRoam");
    }
}
