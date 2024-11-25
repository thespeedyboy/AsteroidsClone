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
  
    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        score = 0;
        UpdateScore();
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
