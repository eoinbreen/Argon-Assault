using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        print(name + " Just Collided With " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(name + " Was Triggered By " + other.gameObject.name);
    }
}
