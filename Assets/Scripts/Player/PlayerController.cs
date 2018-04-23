using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Vector3 initialForce = new Vector3(10, 7, 0);
    public bool startedWhirl = false;
    public bool canSpawn = true;
    public float ImpulsePower = 20;
    public Animator animations;

    public enum PlayerState { Moving, Bouncing, Stuck, MaxSpeed, Teleporting }

    public AudioClip[] Clips;

    private PlayerState currentState;
    private AudioSource Source;
    private Vector3 playerDirection;

    private float boostAmount;
    private float bounceCD = 0.1f;
    private bool reversed = false;
    private float spinCountDown;

    public delegate void changeBoost(float boostChange);
    public static event changeBoost UpdateBoost; 


    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Rigidbody>().AddForce(initialForce, ForceMode.Impulse);
        animations = gameObject.GetComponentInChildren<Animator>();
        currentState = PlayerState.Moving;
        Time.timeScale = 1f;
        boostAmount = 10;
    }

    void Update()
    {
        if (currentState == PlayerState.Bouncing)
        {
            
            bounceCD -= Time.deltaTime;
            if (bounceCD <= 0f)
            {
                currentState = PlayerState.Moving;
                animations.SetBool("justBounced", false);

                bounceCD = 0.1f;
            }
        }



        switch (currentState)
        {
            case PlayerState.Moving:
                Move();
                break;
            case PlayerState.Stuck:
                Stuck();
                break;
            case PlayerState.MaxSpeed:
                MaxSpeed();
                break;
            case PlayerState.Bouncing:
                Bouncing();
                break;
        }

        //for spin anim
        spinCountDown -= Time.deltaTime;
        if (spinCountDown <= 0f)
        {
            animations.SetBool("hitAsteroid", false);
        }

    }

    private void OnCollisionEnter(Collision coll)
    {
       
        if (coll.transform.tag == "Asteroid")
        {
            spinCountDown = 0.5f;
            animations.SetBool("hitAsteroid", true);
            updateBoost(2.0f);
        }
        else if (coll.transform.tag == "SpeedAsteroid")
        {
           
            if(currentState == PlayerState.MaxSpeed)
            {
                spinCountDown = 0.5f;
                animations.SetBool("hitAsteroid", true);
                updateBoost(4.0f);
            }
            else
            {
                animations.SetBool("justBounced", true);
                Vector3 collisionPoint = coll.contacts[0].point;
                Vector3 reverseCollisionVector = -coll.contacts[0].normal;
                Vector3 collisionNormal = new Vector3();
                collisionPoint -= reverseCollisionVector;
                RaycastHit hitInfo;
                if (coll.collider.Raycast(new Ray(collisionPoint, reverseCollisionVector), out hitInfo, 4))
                {
                    collisionNormal = hitInfo.normal;
                }
                Vector3 newVelocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collisionNormal);
                GetComponent<Rigidbody>().velocity = newVelocity * 0.8f;
                updateBoost(-5.0f);
            }
        }
        else if (coll.transform.tag == "WormHole")
        {
            animations.SetBool("hitBlackHole", true);
        }

        else if(coll.transform.tag == "Bumper")
        {
            updateBoost(1.0f);
        }
    }

    

    public void setPlayerState(PlayerState newState)
    {
        currentState = newState;
    }

    public void setPlayerState(PlayerState newState, float timer)
    {
        StartCoroutine(setState(newState, timer));
    }

    public PlayerState getState()
    {
        return currentState;
    }


    private IEnumerator setState(PlayerState newState, float time)
    {
        yield return new WaitForSeconds(time);
        currentState = newState;
    }



    public void disableInput()
    {
        canSpawn = false;
    }

    public void enableInput()
    {
        canSpawn = true;
    }

    public void Launch()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gameObject.GetComponent<Rigidbody>().velocity.normalized * 2, ForceMode.Impulse);

    }

    public void bounceAnimationFinished()
    {
        animations.SetBool("justBounced", false);
    }

    public void setReversed(bool set)
    {
        reversed = set;
    }

    private void Move()
    {
        //protect us from insane speed, set which moving animation we're using
        if (GetComponent<Rigidbody>().velocity.magnitude > 60)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.75f;
        }
        else if (GetComponent<Rigidbody>().velocity.magnitude > 45 && GetComponent<Rigidbody>().velocity.magnitude < 60)
        {
            setPlayerState(PlayerState.MaxSpeed);

        }

        animations.SetBool("fastSwim", false);
        animations.SetBool("slowSwim", true);

        updateBoost(-2.0f * Time.deltaTime);


        //Cat facing direction of movement used for anim
        playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);

        //I don't know what  happened, but this became necessary again. QQ
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);

    }
    private void MaxSpeed()
    {
        animations.SetBool("fastSwim", true);
        animations.SetBool("slowSwim", false);

        if(GetComponent<Rigidbody>().velocity.magnitude < 45)
        {
            setPlayerState(PlayerState.Moving);
        }
        //Cat facing direction of movement used for anim
        playerDirection = GetComponent<Rigidbody>().velocity.normalized;
        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);

        //I don't know what  happened, but this became necessary again. QQ
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }

    private void Bouncing()
    {
        animations.SetBool("justBounced", true);

    }
    private void Stuck()
    {

        playerDirection = GetComponent<Rigidbody>().velocity.normalized;

        gameObject.GetComponentInChildren<Rigidbody>().transform.rotation = Quaternion.LookRotation(-playerDirection); //transform.rotation =  Quaternion.LookRotation(playerDirection);

    }

    private void updateBoost(float boostChange)
    {
        boostAmount += boostChange;
        if(boostAmount>100)
        {
            boostAmount = 100;
        }
        if(boostAmount < 0)
        {
            boostAmount = 0;
        }
        UpdateBoost(boostAmount);
    }
}