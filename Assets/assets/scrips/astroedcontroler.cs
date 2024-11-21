using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroedcontroler : MonoBehaviour
{
    public int pointValue;
    public gamemanager gm;

    [Header("Spliting")]
    public GameObject smallerAsteroid;
    public int SmallerAsteroidtoSpawn;

    private void Start()
    {
        gm = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gm.AddScore(pointValue);
            Destroy(collision.gameObject);
            SpawnSmaller(SmallerAsteroidtoSpawn);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    private void SpawnSmaller(int numberToSpawn)
    {
        if(smallerAsteroid !=null)
        {
            for(int i = 0; i < numberToSpawn; i++)
            {
                Instantiate(smallerAsteroid, transform.position, transform.rotation);
            }
        }
    }
}
