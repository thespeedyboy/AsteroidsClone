using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour
{
    [Header("Movement vals")]
    private float horizontalInput;
    [SerializeField] private float turnSpeed;
    // happens one time in the first frame
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
