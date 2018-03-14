using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class A_GameController : MonoBehaviour {

    [HideInInspector]
    public float timer = 0f;

    [HideInInspector]
    public int numAsteroidsDestroyed = 0;

    [HideInInspector]
    public float clickCadenceCalculator = 0f;

    [HideInInspector]
    public float avgClickDistance;

    private GameObject Player;
    private List<float> clickArray;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        timer += Time.unscaledDeltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }	

        if(Input.GetMouseButtonUp(0))
        {
            clickCadenceCalculator++;

        }


	}

    private void OnDestroy()
    {
        clickCadenceCalculator = clickCadenceCalculator / timer;
    }
}
