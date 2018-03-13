using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_SurveyController : MonoBehaviour {

    //private Statics staticInfo = Statics.Instance;

    [HideInInspector]
    public float timer = 0f;

    [HideInInspector]
    public int numCatSpins = 0;



	
	void Update ()
    {
        
        timer += Time.unscaledDeltaTime;
	}

    
    public void incrementCatSpins()
    {
        numCatSpins++;
    }


    public void checkWentBackToTutorial()
    {
        if (Statics.Instance.beenToGame)
        {
            Statics.Instance.wentBackToTutorial = true;
        }
    }

    public void SetBeenToGame()
    {
        Statics.Instance.beenToGame = true;
    }

    public void SetClickTutorial(bool setBool)
    {
        Statics.Instance.clickedTutorial = setBool;
    }

    public void SetLeftTutorialEarly(bool setBool)
    {
        Statics.Instance.leftTutorialEarly = setBool;
    }


}
