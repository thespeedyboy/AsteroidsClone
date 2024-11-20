using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroedcontroler : MonoBehaviour
{
    public int pointValue;
    public gamemanager gm;

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
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
