using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gamemanager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        scoreDisplay.text = $"Score: {score}";
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
}
