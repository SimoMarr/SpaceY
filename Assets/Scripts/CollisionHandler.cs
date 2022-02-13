using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly": Debug.Log("Bumped into friendly object."); break;
            case "Finish": SuccessSequence(); break;
            default: CrashSequence(); break;
        }    
    }

    void SuccessSequence()
    {
        Invoke("NextLevel", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
    }

    void CrashSequence()
    {
        Invoke("ReloadLevel", levelLoadDelay);
        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
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