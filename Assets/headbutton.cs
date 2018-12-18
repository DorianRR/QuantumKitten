using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headbutton : MonoBehaviour {

    [SerializeField]
    private GameObject EndingSplash = null;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndingSplash.SetActive(true);
        }
    }
}
