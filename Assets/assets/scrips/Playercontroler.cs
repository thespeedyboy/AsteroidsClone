using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour
{
    [Header("Movement vals")]
    private float horizontalInput;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float thrustfForce;
    private Rigidbody rb;
    [Header("shooting")]
    public GameObject bullet;
    public GameObject bulletSpawn;
    [Header("GameManager")]
    public gamemanager gm;

    // happens one time in the first frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("gamemanager").GetComponent<gamemanager>();
    }
    // Update is called once per frame
    void Update()
    {
        //rotashion
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
        //shooting
        if(Input.GetButtonDown("Shoot"))
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Move"))
        {
            rb.AddRelativeForce(Vector3.forward  * thrustfForce);
        }
    }
}
