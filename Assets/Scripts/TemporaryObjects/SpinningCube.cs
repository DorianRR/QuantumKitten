using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCube: MonoBehaviour {

    public GameObject asteroid;

    //public float spawnRate;
    public Vector3 spawnLocation;

    public float upperRotationBounds;
    public float lowerRotationBounds;
    public float upperSizeBounds;
    public float lowerSizeBounds;

    private Vector3 initialImpulse;
    private Vector3 scale;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawnAsteroid());
    }

    IEnumerator spawnAsteroid()
    {
        while(true)
        {
            Debug.Log("test");
            GameObject newCube = Instantiate(asteroid, spawnLocation, Quaternion.identity);
            newCube.transform.SetParent(GameObject.Find("FloatingObjects").transform);
            initialImpulse = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            newCube.GetComponent<Rigidbody>().velocity = initialImpulse * 10;
            scale = new Vector3(Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds));

            newCube.transform.localScale = scale;

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
        
    }

    
}
