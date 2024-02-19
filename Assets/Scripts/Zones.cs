using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zones : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject transition;
    [SerializeField] AudioClip playerDeadSound;

    private Collider2D target;
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isPlayer = other.CompareTag("Player");
        bool isMob = other.CompareTag("Mob");

        if (isPlayer)
        {
            target = other;
            transition.GetComponent<Animator>().SetTrigger("TransitionOut");
            GetComponent<AudioSource>().PlayOneShot(playerDeadSound, 0.2f);
            Invoke(nameof(MoveToSpawn), 0.5f);
       
            transition.GetComponent<Animator>().SetTrigger("TransitionIn");
        }
    }

    private void MoveToSpawn()
    {
        target.transform.position = spawnPoint.position;
        target.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
}
