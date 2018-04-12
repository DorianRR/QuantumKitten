using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedAsteroid : MonoBehaviour
{

    public ParticleSystem explosion;

    private A_GameController GameModeAnalytics;
    private void Awake()
    {
        GameModeAnalytics = GameObject.Find("GameController").GetComponent<A_GameController>();
        gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.MaxSpeed)
            {
                gameObject.GetComponent<Rigidbody>().freezeRotation = true;
               
                
                StartCoroutine(DestroyAst());
            }
        }
    }

    IEnumerator DestroyAst()
    {

        Vector3 tempV = gameObject.transform.localScale;
        GameObject temp = transform.GetChild(0).gameObject;
        Vector3 currentPosition = temp.transform.position;
        //temp.SetActive(true);

        ParticleSystem newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        GameModeAnalytics.numAsteroidsDestroyed++;
        // destroy particle system after play


        //Destroy(explosion.transform);
        //Destroy(newExplosion);
        Destroy(gameObject);
        yield return null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WormHole")
        {
            Destroy(this.gameObject);
        }
    }
}
