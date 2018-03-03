﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_MenuController : MonoBehaviour {

    private Statics staticInfo = Statics.Instance;

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
        if (staticInfo.beenToGame)
        {
            staticInfo.wentBackToTutorial = true;
        }
    }

    public void SetBeenToGame()
    {
        staticInfo.beenToGame = true;
    }

    public void SetClickTutorial(bool setBool)
    {
        staticInfo.clickedTutorial = setBool;
    }

    public void SetLeftTutorialEarly(bool setBool)
    {
        staticInfo.leftTutorialEarly = setBool;
    }


}
