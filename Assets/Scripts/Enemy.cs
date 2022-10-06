using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;

    [SerializeField] int pointValue = 1;
    [SerializeField] int hp = 2;
    
    ScoreBoard scoreBoard;
    GameObject bin;

    private void Start()
    {
        createRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>(); // Keeps same scoreboard throughout game
        bin = GameObject.FindGameObjectWithTag("Bin");
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
            GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            vfx.transform.SetParent(bin.transform);
            Destroy(gameObject);
            ProcessScore();
        }
    }

    private void ProcessScore()
    {
        scoreBoard.IncreaseScore(pointValue);
    }
}
