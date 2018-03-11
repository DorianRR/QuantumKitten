using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public ParticleSystem explosion;

    private A_GameController GameModeAnalytics;
    

    private void Awake()
    {
        GameModeAnalytics = GameObject.Find("GameController").GetComponent<A_GameController>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("TestHIt");
            StartCoroutine(DestroyAst());
        }
    }

    IEnumerator DestroyAst()
    {

        //Vector3 tempV = gameObject.transform.localScale;
        //GameObject temp = transform.GetChild(0).gameObject;
        //Vector3 currentPosition = temp.transform.position;
        //temp.SetActive(true);

        Instantiate(explosion, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(0.0f);
        GameModeAnalytics.numAsteroidsDestroyed++;
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
