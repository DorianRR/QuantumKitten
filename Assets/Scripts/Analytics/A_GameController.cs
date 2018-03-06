using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class A_GameController : MonoBehaviour {

    [HideInInspector]
    public float timer = 0f;

    [HideInInspector]
    public int numAsteroidsDestroyed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.unscaledDeltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }	
	}
}
