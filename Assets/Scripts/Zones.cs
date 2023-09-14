using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isPlayer = other.CompareTag("Player");
        bool isMob = other.CompareTag("Mob");

        if (isPlayer || isMob)
        {
            ChangePosition(other, spawnPoint);
            SetFallSpeed(other, Vector2.zero);
          
        }
    }

    private void ChangePosition(Collider2D target, Transform spawnHere)
    {
        target.transform.position = spawnHere.position;
    }

    private void SetFallSpeed(Collider2D target, Vector2 speed)
    {
        target.GetComponent<Rigidbody2D>().velocity = speed;
    }
}
