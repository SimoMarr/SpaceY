using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int iThrust = 5000;
    int iRotation = 250;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * iThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(iRotation);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-iRotation);
        }
    }

    void ApplyRotation(int direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * direction * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
