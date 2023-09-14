using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    [SerializeField] private float jumpForce = 200f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();

            playerBody.velocity = new Vector2(playerBody.velocity.x, 0);

            playerBody.AddForce(new Vector2(0, jumpForce));

            GetComponent<Animator>().SetTrigger("Jump");

        }
    }
}
