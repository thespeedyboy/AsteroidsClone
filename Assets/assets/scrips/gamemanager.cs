using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gamemanager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    //ScreenLimits
    [Header("Screen Limits")]
    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;
    public float safetyRadius;

    [Header("lives")]
    public int maxLives;
    private int lives;
    public TextMeshProUGUI livesDisplay;
    public GameObject gameOverDisplay;
    public Vector3 spawnPoint = Vector3.zero;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        score = 0;
        UpdateScore();
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }
    public void UpdateLives()
    {
        livesDisplay.text = $"Lives: {lives}";
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
    public void LoseLife()
    {
        lives--;
        UpdateLives();
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1);
        //check to see if spawn is clear
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");

        bool canSpawn = false;

        while(!canSpawn)
        {
            canSpawn = true;
            foreach(GameObject enemy in enemys)
            {
                if((enemy.transform.position - spawnPoint).magnitude < safetyRadius)
                {
                    enemy.GetComponent<Rigidbody>().AddForce((enemy.transform.position - spawnPoint).normalized * 10, ForceMode.Impulse);
                    canSpawn = false;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
        Instantiate(playerPrefab, spawnPoint, playerPrefab.transform.rotation);



    }
    public void PlayerDie()
    {
        LoseLife();
        StartCoroutine(RespawnPlayer());
    }
}
