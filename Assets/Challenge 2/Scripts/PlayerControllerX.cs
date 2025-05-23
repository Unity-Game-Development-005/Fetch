
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // time to wait before sending dog
    private float waitTime;

    // can send dog flag
    private bool canSendDog = true;


    private void Start()
    {
        Initialise();
    }


    // Update is called once per frame
    void Update()
    {
        SendDog();

        RunTimer();
    }


    private void SendDog()
    {
        if (canSendDog)
        {
            // and the spacebar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // send the dog
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

                canSendDog = false;
            }
        }
    }


    private void Initialise()
    {
        waitTime = 2f;
    }


    private void RunTimer()
    {
        if (!canSendDog)
        {
            waitTime -= Time.deltaTime;

            if (waitTime <= 0)
            {
                canSendDog = true;

                waitTime = 2f;
            }
        }
    }


} // end of class
