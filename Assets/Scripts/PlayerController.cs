using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 initialForce = new Vector3(10,7,0);
    // Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
