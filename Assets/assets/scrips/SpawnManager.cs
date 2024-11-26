using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public gamemanager gm;
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    public GameObject player;

    public GameObject enemy;
    public int enemysToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        player = GameObject.Find("player");
        xMax = gm.xMax;
        xMin = gm.xMin;
        zMax = gm.zMax;
        zMin = gm.zMin;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
        {
            SpawnWave(enemysToSpawn);
        }
    }
    public Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(xMin, xMax);
        float randomZ = Random.Range(zMin, zMax);
        Vector3 randomPos = new Vector3(randomX, 1, randomZ);
        while((randomPos - player.transform.position).magnitude < gm.safetyRadius)
        {
            randomX = Random.Range(xMin, xMax);
            randomZ = Random.Range(zMin, zMax);
            randomPos = new Vector3(randomX, 1, randomZ);
        }

        return randomPos;
    }

    public void SpawnWave(int Enemys)
    {
        for(int i = 0; i < Enemys; i++)
        {
            Instantiate(enemy, GenerateRandomPosition(), transform.rotation);

        }
    }
}
