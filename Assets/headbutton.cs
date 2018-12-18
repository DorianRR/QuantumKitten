using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class headbutton : MonoBehaviour {




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("ppp");

            SceneManager.LoadScene("EndVideo");
        }
    }
}
