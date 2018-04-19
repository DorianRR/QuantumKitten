using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDespawn : MonoBehaviour
{
    public AudioClip[] Clips;
    public GameObject GravityWell;
    Ray touchRay;
    RaycastHit touchHit;
    //public float cooldown = 2f;

    private AudioSource Source;
    private GameObject spawnedWell;
    private GameObject MainCamera;

    private bool activeWell = false;

    private void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        MainCamera = GameObject.Find("Main Camera");
    }

    void Update()
    {

        if (!activeWell && Input.GetMouseButtonDown(0) && (gameObject.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.Moving || gameObject.GetComponent<PlayerController>().getState() == PlayerController.PlayerState.MaxSpeed))
        {
            activeWell = true;
            gameObject.GetComponent<ObjectiveIndicator>().externalPause = true;
            touchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(touchRay, out touchHit);
            if (touchHit.transform.tag == "Clickable")
            {
                Source.PlayOneShot(Clips[0]);
                spawnedWell = Instantiate(GravityWell, touchHit.point, Quaternion.identity);

                //MainCamera.GetComponent<CameraController>().CenterOnSpawnedGW(touchHit.point);
            }

        }
        else if (Input.GetMouseButtonDown(0))
        {
            activeWell = false;
            gameObject.GetComponent<ObjectiveIndicator>().externalPause = false;

            //gameObject.GetComponent<PlayerController>().setWhirl(false);
            gameObject.GetComponent<PlayerController>().Launch();


            Destroy(spawnedWell);
            MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

        }

        if (spawnedWell)
        {
            float distance = (spawnedWell.transform.position - transform.position).magnitude;
            //float distance= 10f;

            //FIX THIS SECTION
            if (distance < 5f)
            {
                gameObject.GetComponent<ObjectiveIndicator>().externalPause = false;

                //gameObject.GetComponent<PlayerController>().setWhirl(false);


                //Destroy(spawnedWell);
                ForcedDeSpawn();

                //MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

                //MainCamera.GetComponent<CameraController>().reCenter();


            }
        }
    }

    public void ForcedDeSpawn()
    {
        activeWell = false;
        //gameObject.GetComponent<PlayerController>().setWhirl(false);
        gameObject.GetComponent<PlayerController>().Launch();


        Destroy(spawnedWell);
        MainCamera.GetComponent<CameraController>().setCenteredOnGW(false);

        //MainCamera.GetComponent<CameraController>().reCenter();
    }


}