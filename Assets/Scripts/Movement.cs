using UnityEngine;

public class Movement : MonoBehaviour
{
    int iThrust = 3000;
    int iRotation = 200;

    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem thrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            StartThrustingLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            StartThrustingRight();
        }
        else
        {
            StopSideThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * iThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineSound);
        }
        if (!thrustParticles.isPlaying)
        {
            thrustParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        thrustParticles.Stop();
    }

    void StartThrustingLeft()
    {
        ApplyRotation(iRotation);
        if (!rightThrustParticles.isPlaying)
        {
            rightThrustParticles.Play();
        }
    }

    void StartThrustingRight()
    {
        ApplyRotation(-iRotation);
        if (!leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Play();
        }
    }

    void StopSideThrusting()
    {
        rightThrustParticles.Stop();
        leftThrustParticles.Stop();
    }

    void ApplyRotation(int direction)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * direction * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
