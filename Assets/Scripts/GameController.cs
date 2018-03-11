using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public enum Level { Start, Middle, Boss}
    private bool objectiveState;
    private Level currentLevel;
    
    // Use this for initialization
	void Start () {
        currentLevel = Level.Start;
        objectiveState = false;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void changeLevel(Level newLevel)
    {
        currentLevel = newLevel;
        objectiveState = false;
    }
  
}
