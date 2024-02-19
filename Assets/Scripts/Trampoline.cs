using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{


    private Collider2D target;
    [SerializeField] private float jumpForce = 200f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Mob"))
        {
            target = other;

            Invoke(nameof(Jump), 0.1f);

        }
    }

    private void Jump()
    {
        Rigidbody2D body = target.GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(body.velocity.x, 0);

        body.AddForce(new Vector2(0, jumpForce));

        GetComponent<Animator>().SetTrigger("Jump");
    }
}
