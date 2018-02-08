using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportEffect : MonoBehaviour {

    private GameObject[] exitHoles;
	void Start () {
        exitHoles = GameObject.FindGameObjectsWithTag("ExitHole");
	}
	

	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            int holeNumber = Random.Range(0, exitHoles.Length);
            Vector3 holePosition = exitHoles[holeNumber].transform.position;
            Vector3 newDirection = Random.onUnitSphere.normalized;
            newDirection.z = 0;
            collision.transform.position = holePosition;
            collision.transform.GetComponent<Rigidbody>().AddForce(newDirection * 10, ForceMode.Impulse);

        }
    }
}
