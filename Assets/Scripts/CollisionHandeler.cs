using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    int currentLevel;
    [SerializeField] ParticleSystem explosion;

    private void OnTriggerEnter(Collider other)
    {
        Crash();
    }

    void Crash()
    {
        explosion.Play();
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;// disable PlayerControls Script
        Invoke("ReloadLevel", 1f);//1 second delay on reloading Level to play audio and particles
    }

    void ReloadLevel()
    {
       
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}

