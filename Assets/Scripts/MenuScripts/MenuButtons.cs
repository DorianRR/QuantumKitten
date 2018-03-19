using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    //public void TutorialButton()
    //{
    //    SceneManager.LoadScene(2);
    //}

    public void SurveyButton()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitApp()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
