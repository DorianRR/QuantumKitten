using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedAsteroid : MonoBehaviour {

    public ParticleSystem explosion;

    private A_GameController GameModeAnalytics;

    private void Awake()
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);

        FadeInAndScoot();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;

            StartCoroutine(DestroyAst());

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

    public void FadeInAndScoot()
    {

        GameModeAnalytics = GameObject.Find("GameController").GetComponent<A_GameController>();
        gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2)));

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
        StartCoroutine(Fade());

    }

    IEnumerator Fade()
    {

        while (gameObject.transform.localScale.x < 250)
        {
            Debug.Log("Made it into fade");

            gameObject.transform.localScale += new Vector3(3, 3, 3);
            yield return new WaitForSeconds(0.01f);
        }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WormHole")
        {
            Destroy(this.gameObject);
        }
    }
}
