using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;

    [SerializeField] int pointValue = 1;
    [SerializeField] int hp = 2;
    
    ScoreBoard scoreBoard;

    private void Start()
    {
        createRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Keeps same scoreboard throughout game
    }

    void createRigidbody()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    
    private void ProcessHit()
    {
        if (hp > 0)
        {
            hp --;
            print(name + " HP is now " + hp);
        }
        else
        {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ProcessScore();
        }
    }

    private void ProcessScore()
    {
        scoreBoard.IncreaseScore(pointValue);
    }
}
