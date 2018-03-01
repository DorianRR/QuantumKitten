using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public ParticleSystem explosion;

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
        Vector3 currentPosition = temp.transform.position;
        //temp.SetActive(true);

        Instantiate(explosion, transform.position, Quaternion.identity);

        //for (int i = 0; i < 30; i++)
        //{
        //    tempV = tempV * 0.75f;
        //    gameObject.transform.localScale =tempV;
        //    gameObject.transform.position = currentPosition;

        //    //Turns off the mesh render for the game object.
        //    MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
        //    rend.enabled = false;

        //    yield return new WaitForSeconds(0.01f);

        //}
        
        //temp.transform.parent = null;
        //Destroy(temp);

        yield return new WaitForSeconds(0.0f);
        Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "WormHole")
        {
            Destroy(this.gameObject);
        }
    }
}
