using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
//using System.Collections.Generic;


public class Statics : MonoBehaviour {

    public static Statics Instance
    {
        get;
        set;
    }

    [HideInInspector]
    public float fullGameSessionTimer;

    [HideInInspector]
    public bool wentBackToTutorial;

    [HideInInspector]
    public bool leftTutorialEarly;

    [HideInInspector]
    public bool clickedTutorial;

    [HideInInspector]
    public bool beenToGame;


    [HideInInspector]
    public bool isInstiantiated = false;

    
    void Start ()
    {

        if(Instance == null)
        {
            Instance = this;
            isInstiantiated = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }

	}

    //void Start()
    //{
    //    SceneManager.LoadScene(0);
    //}
	
	void Update ()
    {
        fullGameSessionTimer += Time.unscaledDeltaTime;

        if(Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }
    }



}
