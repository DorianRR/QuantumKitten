using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    // Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(10, 7, 0), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
