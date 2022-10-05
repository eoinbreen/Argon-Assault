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
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Keeps same scoreboard throughout game
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessScore();
        ProcessHit();
    }

    private void ProcessScore()
    {
        scoreBoard.IncreaseScore(pointValue);
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
        }
    }
}
