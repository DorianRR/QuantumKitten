using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(DestroyAst());
        }
    }

    IEnumerator DestroyAst()
    {
        
        Vector3 tempV = gameObject.transform.localScale;
        GameObject temp = transform.GetChild(0).gameObject;
        temp.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            tempV = tempV * 0.75f;
            gameObject.transform.localScale =tempV;
            yield return new WaitForSeconds(0.01f);
            
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);


    }


}
