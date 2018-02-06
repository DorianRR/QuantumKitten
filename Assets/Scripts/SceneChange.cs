using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
