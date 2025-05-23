
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float randomStartDelay = 1.0f;

    private float randomSpawnInterval = 4.0f;



    // Start is called before the first frame update
    void Start()
    {
        SelectRandomBallDropRate();

        // InvokeRepeating("SpawnRandomBall", randomStartDelay, randomSpawnInterval);
    }


    private void SelectRandomBallDropRate()
    {
        // select a random drop time base on the start delay time
        float nextBall = Random.Range(randomStartDelay, randomStartDelay * randomSpawnInterval);

        // spawn a random ball
        Invoke("SpawnRandomBall", nextBall);

        // select another randop drop rate
        Invoke("SelectRandomBallDropRate", nextBall);
    }


    // spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int randomBall = Random.Range(0, ballPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBall], spawnPos, ballPrefabs[randomBall].transform.rotation);
    }


} // end of class
