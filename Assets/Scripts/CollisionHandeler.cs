using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    int currentLevel;
   

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<PlayerControls>().enabled = false;// disable PlayerControls Script
        Invoke("ReloadLevel", 1f);//1 second delay on reloading Level to play audio and particles
    }

    void ReloadLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}

