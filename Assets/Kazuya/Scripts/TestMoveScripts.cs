using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScripts : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           rb.AddForce(new Vector3(-35,0,0),ForceMode.VelocityChange);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector3(10,0,0),ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0, 0), ForceMode.VelocityChange);
        }
    }
}
