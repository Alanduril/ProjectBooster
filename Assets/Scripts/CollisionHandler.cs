using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
       int currentSceneIndex;
    int maxScenes;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        maxScenes = SceneManager.sceneCountInBuildSettings - 1;
    }
    void OnCollisionEnter(Collision other)
    {
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("You're safe!");
            break;
            case "Finish":
            NextlevelSequence();           
            break;
            default:
            StartCrashSequence();           
            break;
        }
    }

    private void NextlevelSequence()
    {
        GetComponent<Movement>().enabled= false;
        Invoke("nextLevel", delay); 
    }

    [SerializeField] float delay = 2f;
    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled= false;
        Invoke("ReloadLevel", delay);       
    }

    void ReloadLevel()
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
         void nextLevel()
        {
            if (currentSceneIndex == maxScenes)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }        
    }
}

