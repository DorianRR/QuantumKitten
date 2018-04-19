using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thingtest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<CameraController>().callHover(GameObject.Find("Boss").transform.position);
        }
    }
}
