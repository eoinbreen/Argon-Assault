using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;

    [SerializeField] int pointValue = 1;
    
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Keeps same scoreboard throughout game
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessScore();
        KillEnemy();
    }

    private void ProcessScore()
    {
        scoreBoard.IncreaseScore(pointValue);
    }

    private void KillEnemy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
