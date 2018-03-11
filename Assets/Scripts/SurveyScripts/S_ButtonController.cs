using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ButtonController : MonoBehaviour {

    [HideInInspector]
    public string answer1;

    [HideInInspector]
    public string answer2;

    [HideInInspector]
    public string answer3;

    [HideInInspector]
    public string answer4;

    [HideInInspector]
    public string answer5;
    


    public void FirstButton(string input)
    {
        answer1 = input;
    }

    public void SecondButton(string input)
    {
        answer2 = input;
    }

    public void ThirdButton(string input)
    {
        answer3 = input;
    }


}
