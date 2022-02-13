using UnityEngine;

public class Movement : MonoBehaviour
{
    int iThrust = 3000;
    int iRotation = 200;
    Rigidbody rb;
    AudioSource audioSource; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

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
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
            {
                audioSource.Stop();
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
