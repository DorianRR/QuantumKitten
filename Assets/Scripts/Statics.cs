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

    
    void Awake ()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
        SceneManager.LoadScene(0);
    }
	
	void Update ()
    {
        fullGameSessionTimer += Time.unscaledDeltaTime;
    }

}
