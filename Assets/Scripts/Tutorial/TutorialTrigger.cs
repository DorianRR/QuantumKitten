using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour {

    public GameObject ChildCanvas;

    private TutorialController controller;
    private GameObject Player;



    void Start ()
    {
        controller = GameObject.Find("TutorialController").GetComponent<TutorialController>();
        Player = GameObject.Find("Player");

	}
	
	
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            StartCoroutine(ThereHasToBeABetterWayToWait());

            controller.CallFadeSlow();
        }

        if(gameObject.name == "TriggerZone2" && gameObject.name == "Player")
        {
            StartCoroutine(LerpWall());
        }
    }

    IEnumerator ThereHasToBeABetterWayToWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        ChildCanvas.SetActive(true);

    }

    IEnumerator LerpWall()
    {
        GameObject temp = GameObject.Find("MovingBound");

        while (Mathf.Abs(temp.transform.position.y) > 10f)
        {
            temp.transform.position = new Vector3(temp.transform.position.x, temp.transform.position.y - 0.15f, temp.transform.position.z);
            yield return new WaitForSeconds(0.01f);

        }
    }

    public void spawnWell()
    {
        controller.CallFadeToNormalSpeed();
        ChildCanvas.SetActive(false);
    }
}
