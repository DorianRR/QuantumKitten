using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawn : MonoBehaviour {

    public GameObject GravityWell;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed left click");
	}
}
