﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedAsteroid : MonoBehaviour
{

    public ParticleSystem explosion;

    private A_GameController GameModeAnalytics;
    private void Awake()
    {
        GameModeAnalytics = GameObject.Find("GameController").GetComponent<A_GameController>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.MaxSpeed)
            {
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

        Instantiate(explosion, transform.position, Quaternion.identity);
        Debug.Log("destroy speed ast");
        GameModeAnalytics.numAsteroidsDestroyed++;
        yield return new WaitForSeconds(0.0f);
        Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WormHole")
        {
            Destroy(this.gameObject);
        }
    }
}
