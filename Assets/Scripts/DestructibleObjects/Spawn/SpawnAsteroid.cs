using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{

    public GameObject asteroid;

    //public float spawnRate;
    private Vector3 spawnLocation;
    public int maxAsteroids = 50;
    public int startingAsteroids = 20;
    private int currentAsteroids;
    public int waveSize = 10;
    private float waveTimer;
    private float spawnTimer;

    public float upperRotationBounds;
    public float lowerRotationBounds;
    public float upperSizeBounds;
    public float lowerSizeBounds;
    private GameObject[] holes;

    private Vector3 initialImpulse;
    private Vector3 scale;

    // Use this for initialization
    void Start()
    {
        spawnTimer = 0.2f;
        holes = GameObject.FindGameObjectsWithTag("ExitHole");
        currentAsteroids = 0;
        waveTimer = 10f;
        StartCoroutine(SpawnInitialWave());
    }

    private void Update()
    {
        waveTimer -= Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        if (maxAsteroids - currentAsteroids > 10 && waveTimer <= 0)
        {
            spawnWave();
            waveTimer = 10f;
        }
    }


    IEnumerator asteroidWait()
    {
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator SpawnInitialWave()
    {
        while (currentAsteroids < startingAsteroids)
        {

            spawnLocation = holes[Random.Range(0, 2)].transform.position;
            GameObject newAsteroid = Instantiate(asteroid, spawnLocation, Quaternion.identity);
            newAsteroid.transform.SetParent(GameObject.Find("FloatingObjects").transform);
            initialImpulse = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            newAsteroid.GetComponent<Rigidbody>().velocity = initialImpulse * 50;
            scale = new Vector3(Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds));

            newAsteroid.transform.localScale = scale;
            currentAsteroids++;
            yield return new WaitForSeconds(3f);

        }
    }


    private void spawnWave()
    {
        int newCurrentTimer = 0;
        while (newCurrentTimer < waveSize)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                spawnLocation = holes[Random.Range(0, 2)].transform.position;
                GameObject newAsteroid = Instantiate(asteroid, spawnLocation, Quaternion.identity);
                newAsteroid.transform.SetParent(GameObject.Find("FloatingObjects").transform);
                initialImpulse = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
                newAsteroid.GetComponent<Rigidbody>().velocity = initialImpulse;
                scale = new Vector3(Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds), Random.Range(upperSizeBounds, lowerSizeBounds));

                newAsteroid.transform.localScale = scale;
                newCurrentTimer++;
                spawnTimer = 0.5f;
            }
        }
        currentAsteroids += waveSize;
    }
    public void destroyAsteroid()
    {
        currentAsteroids--;
    }

    private IEnumerator startSpawn()
    {
        yield return new WaitForSeconds(3f);
        SpawnInitialWave();
    }
}