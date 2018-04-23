using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject[] Asteroid;
    public GameObject[] SpeedAsteroid;
    private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer > 5.5)
        {
            timer = 0;
            SpawnAsteroid();
        }
	}

    private void SpawnAsteroid()
    {
        int temp = Random.Range(0, Asteroid.Length);

        Instantiate(Asteroid[temp], gameObject.transform.position, Quaternion.identity);
    }
}
