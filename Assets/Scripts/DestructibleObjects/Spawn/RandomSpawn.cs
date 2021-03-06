﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] asteroids;

    public int numberOfObjects;

    public float upperXBounds;
    public float lowerXBounds;
    public float upperYBounds;
    public float lowerYBounds;

    public float upperRotationBounds;
    public float lowerRotationBounds;

    public float upperSizeBounds;
    public float lowerSizeBounds;

    // Use this for initialization
    void Start()
    {
        Vector3 position;
        Vector3 scale;

        for (int i = 0; i < numberOfObjects; i++)
        {
            position = new Vector3(Random.Range(upperXBounds, lowerXBounds), Random.Range(upperYBounds, lowerYBounds), 0);
            scale = new Vector3(Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds));

            GameObject newCube = Instantiate(asteroids[Random.Range(0,asteroids.Length)], position, Quaternion.identity);
            newCube.transform.SetParent(GameObject.Find("FloatingObjects").transform);


            newCube.transform.localScale = scale;
            newCube.GetComponent<Rigidbody>().AddTorque(transform.up * Random.Range(upperRotationBounds, lowerRotationBounds));
            newCube.GetComponent<Rigidbody>().AddTorque(transform.right * Random.Range(upperRotationBounds, lowerRotationBounds));
        }
    }


}
