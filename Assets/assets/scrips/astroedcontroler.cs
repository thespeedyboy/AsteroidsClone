using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroedcontroler : MonoBehaviour
{
    public int pointValue;
    public gamemanager gm;
    public Rigidbody rb;

    [Header("Spliting")]
    public GameObject smallerAsteroid;
    public int SmallerAsteroidtoSpawn;
    [Header("Random force variables")]
    public float forceRange;
    public float torqueRange;


    private void Start()
    {
        gm = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        rb = GetComponent<Rigidbody>();

        AddRandomForce();
        AddRandomTorque();
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
            gm.PlayerDie();
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
    public void AddRandomForce()
    {
        float randomForceX = Random.Range(-forceRange, forceRange);
        float randomForceZ = Random.Range(-forceRange, forceRange);
        Vector3 randomForce = new Vector3(randomForceX, 0,  randomForceZ);

        rb.AddForce(randomForce, ForceMode.Impulse);
    }

    public void AddRandomTorque()
    {
        float randomTorque = Random.Range(-torqueRange, torqueRange);
        rb.AddTorque(Vector3.back * randomTorque, ForceMode.Impulse);
    }
}
