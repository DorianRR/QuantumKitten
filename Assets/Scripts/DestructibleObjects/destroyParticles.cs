using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Kill());
	}
	
	IEnumerator Kill()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
