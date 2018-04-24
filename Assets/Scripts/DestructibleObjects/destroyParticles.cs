using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticles : MonoBehaviour {

    public AudioClip[] Clips;

	// Use this for initialization
	void Awake () {

        StartCoroutine(Kill());
        

	}
	
	IEnumerator Kill()
    {
        //AudioSource source = gameObject.GetComponent<AudioSource>();
        //source.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
