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
            GameObject.Find("GameController").GetComponent<SpawnAsteroid>().destroyAsteroid();
            StartCoroutine(DestroyAst());
        }
    }

    IEnumerator DestroyAst()
    {

        Vector3 tempV = gameObject.transform.localScale;
        GameObject temp = transform.GetChild(0).gameObject;
        Vector3 currentPosition = temp.transform.position;
        temp.SetActive(true);
        for (int i = 0; i < 30; i++)
        {
            tempV = tempV * 0.75f;
            gameObject.transform.localScale =tempV;
            gameObject.transform.position = currentPosition;
            yield return new WaitForSeconds(0.01f);
            
        }
        temp.transform.parent = null;
        yield return new WaitForSeconds(0.5f);
        Destroy(temp);
        Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "WormHole")
        {
            GameObject.Find("GameController").GetComponent<SpawnAsteroid>().destroyAsteroid();
            Destroy(this.gameObject);
        }
    }

    
}
