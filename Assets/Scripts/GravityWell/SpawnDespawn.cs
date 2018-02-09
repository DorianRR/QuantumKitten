using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawn : MonoBehaviour
{

    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;
    //public float cooldown = 2f;

    private GameObject spawnedWell;
    private GameObject MainCamera;
    private bool onSpawn = true;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");
    }
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<PlayerController>().canSpawn && onSpawn)
        {
            gameObject.GetComponent<ObjectiveIndicator>().externalPause = true;
            onSpawn = false;
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

            MainCamera.GetComponent<CameraController>().CenterOnSpawnedGW(touchHit.point);


        }
        //if (Input.GetMouseButtonUp(0))
        else if (Input.GetMouseButtonDown(0) && !onSpawn)
        {
            gameObject.GetComponent<ObjectiveIndicator>().externalPause = false;

            onSpawn = true;
            gameObject.GetComponent<PlayerController>().setWhirl(false);
            gameObject.GetComponent<PlayerController>().Launch();


            Destroy(spawnedWell);
            MainCamera.GetComponent<CameraController>().reCenter();

        }

        if(spawnedWell)
        {
            float distance = (spawnedWell.transform.position - transform.position).magnitude;
            if (distance < 5f)
            {
                gameObject.GetComponent<ObjectiveIndicator>().externalPause = false;

                onSpawn = true;
                gameObject.GetComponent<PlayerController>().setWhirl(false);


                Destroy(spawnedWell);
                MainCamera.GetComponent<CameraController>().reCenter();


            }
        }
    }

    public void ForcedDeSpawn()
    {
        onSpawn = true;
        gameObject.GetComponent<PlayerController>().setWhirl(false);
        gameObject.GetComponent<PlayerController>().Launch();


        Destroy(spawnedWell);
        MainCamera.GetComponent<CameraController>().reCenter();
    }


}