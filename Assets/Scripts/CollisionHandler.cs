using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip crashSound;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    
    AudioSource audioSource;

    float levelLoadDelay = 1f;
    bool isTransitioning = false;
    bool disableCollisions = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        DebugKeyRespond();
    }

    void DebugKeyRespond()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            disableCollisions = !disableCollisions; //toggle
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || disableCollisions) return;
        switch(other.gameObject.tag)
        {
            case "Friendly": Debug.Log("Bumped into friendly object."); break;
            case "Finish": SuccessSequence(); break;
            default: CrashSequence(); break;
        }    
    }

    void SuccessSequence()
    {
        isTransitioning = true;
        Invoke("NextLevel", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        successParticles.Play();
    }

    void CrashSequence()
    {
        isTransitioning = true;
        Invoke("ReloadLevel", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticles.Play();
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }
}