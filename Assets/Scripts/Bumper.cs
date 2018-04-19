using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    public AudioClip[] Clips;

    Animator anim;

    private AudioSource Source;


    // Use this for initialization
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Source.PlayOneShot(Clips[Random.Range(0, Clips.Length)]);
            if (!anim.GetBool("Hit"))
            {
                anim.SetBool("Hit", true);
                StartCoroutine(endAnimation());
            }
        }


    }

    IEnumerator endAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Hit", false);
    }

}